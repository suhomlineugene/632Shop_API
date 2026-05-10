using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Abp.Domain.Repositories;
using Abp.UI;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration;
using ExcelDataReader;
using Microsoft.Extensions.Configuration;
using SixThreeTwo_shop.Shared.Products;
using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Products;

public class ProductsAppService(
  IRepository<Product> productRepository,
  IRepository<MotorOil> motorOilRepository,
  IRepository<Coolant> coolantRepository,
  IRepository<TransmissionFluid> transmissionFluidRepository,
  IRepository<Additive> additiveRepository,
  IConfiguration configuration)
  : SixThreeTwo_shopAppServiceBase, IProductsAppService
{
  public async Task<List<ProductDto>> GetAllProducts()
  {
    var products = await (await productRepository.GetAllAsync())
      .Include(p => p.MotorOil)
      .Include(p => p.Coolant)
      .Include(p => p.TransmissionFluid)
      .Include(p => p.Additive)
      .ToListAsync();
    return ObjectMapper.Map<List<ProductDto>>(products);
  }

  public async Task<ProductDto> GetProductById(int id)
  {
    var product = await productRepository.GetAll()
      .Include(p => p.MotorOil)
      .Include(p => p.Coolant)
      .Include(p => p.TransmissionFluid)
      .Include(p => p.Additive)
      .FirstOrDefaultAsync(p => p.Id == id);
    return ObjectMapper.Map<ProductDto>(product);
  }

  public async Task<int> CreateOrEditProduct(CreateEditProductDto productDto)
  {
    if (productDto.Id == 0)
    {
      var product = ObjectMapper.Map<Product>(productDto);
      var id = await productRepository.InsertAndGetIdAsync(product);
      await HandleLinkedEntityAsync(id, productDto);
      return id;
    }
    else
    {
      var product = await productRepository.GetAsync(productDto.Id);
      ObjectMapper.Map(productDto, product);
      await productRepository.UpdateAsync(product);
      await HandleLinkedEntityAsync(product.Id, productDto);
      return product.Id;
    }
  }

  public async Task DeleteProduct(int id)
  {
    await productRepository.DeleteAsync(id);
  }

  public List<DropdownDto> GetProductTypeDropdown()
  {
    return Enum.GetValues<ProductType>()
      .Select(pt => new DropdownDto { Id = (int)pt, Name = pt.ToString() })
      .ToList();
  }

  public async Task<int> ImportProductsFromFile(Stream fileStream, string fileName)
  {
    var settings = configuration
      .GetSection(ProductImportSettings.SectionName)
      .Get<ProductImportSettings>() ?? new ProductImportSettings();

    var chunkSize = settings.ChunkSize > 0 ? settings.ChunkSize : ProductImportSettings.DefaultChunkSize;

    var extension = Path.GetExtension(fileName).ToLowerInvariant();

    var records = extension switch
    {
      ".csv" => ReadCsvRecords(fileStream),
      ".xlsx" or ".xls" => ReadExcelRecords(fileStream),
      _ => throw new UserFriendlyException(
        $"Unsupported file type '{extension}'. Please upload a .csv or .xlsx file.")
    };

    var total = 0;
    var chunk = new List<ProductDto>(chunkSize);

    foreach (var dto in records)
    {
      dto.Id = 0; // always insert
      chunk.Add(dto);

      if (chunk.Count < chunkSize) continue;
      await InsertChunkAsync(chunk);
      total += chunk.Count;
      chunk.Clear();
    }

    if (chunk.Count <= 0) return total;
    await InsertChunkAsync(chunk);
    total += chunk.Count;

    return total;
  }

  private async Task HandleLinkedEntityAsync(int productId, CreateEditProductDto dto)
  {
    await CleanupOldLinkedEntitiesAsync(productId, dto.ProductType);

    switch (dto.ProductType)
    {
      case ProductType.MotorOil:
        var motorOil = await motorOilRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (motorOil == null)
          await motorOilRepository.InsertAsync(new MotorOil { ProductId = productId, Viscosity = dto.Viscosity });
        else
        {
          motorOil.Viscosity = dto.Viscosity;
          await motorOilRepository.UpdateAsync(motorOil);
        }

        break;

      case ProductType.Coolant:
        var coolant = await coolantRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (coolant == null)
          await coolantRepository.InsertAsync(new Coolant { ProductId = productId, Approval = dto.CoolantApproval });
        else
        {
          coolant.Approval = dto.CoolantApproval;
          await coolantRepository.UpdateAsync(coolant);
        }

        break;

      case ProductType.TransmissionFluid:
        var fluid = await transmissionFluidRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
        var viscosity = dto.TransmissionType == TransmissionType.Manual ? dto.TransmissionViscosity : null;
        if (fluid == null)
          await transmissionFluidRepository.InsertAsync(new TransmissionFluid
          {
            ProductId = productId,
            Viscosity = viscosity,
            TransmissionType = dto.TransmissionType
          });
        else
        {
          fluid.Viscosity = viscosity;
          fluid.TransmissionType = dto.TransmissionType;
          await transmissionFluidRepository.UpdateAsync(fluid);
        }

        break;

      case ProductType.Additive:
        var additive = await additiveRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (additive == null)
          await additiveRepository.InsertAsync(new Additive { ProductId = productId, AdditiveType = dto.AdditiveType });
        else
        {
          additive.AdditiveType = dto.AdditiveType;
          await additiveRepository.UpdateAsync(additive);
        }

        break;
    }
  }

  private async Task CleanupOldLinkedEntitiesAsync(int productId, ProductType keep)
  {
    if (keep != ProductType.MotorOil)
    {
      var old = await motorOilRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
      if (old != null) await motorOilRepository.DeleteAsync(old);
    }

    if (keep != ProductType.Coolant)
    {
      var old = await coolantRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
      if (old != null) await coolantRepository.DeleteAsync(old);
    }

    if (keep != ProductType.TransmissionFluid)
    {
      var old = await transmissionFluidRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
      if (old != null) await transmissionFluidRepository.DeleteAsync(old);
    }

    if (keep != ProductType.Additive)
    {
      var old = await additiveRepository.FirstOrDefaultAsync(x => x.ProductId == productId);
      if (old != null) await additiveRepository.DeleteAsync(old);
    }
  }

  private async Task InsertChunkAsync(List<ProductDto> chunk)
  {
    using var uow = UnitOfWorkManager.Begin(TransactionScopeOption.RequiresNew);

    foreach (var product in chunk.Select(dto => ObjectMapper.Map<Product>(dto)))
    {
      await productRepository.InsertAsync(product);
    }

    await uow.CompleteAsync();
  }

  // Reads directly from the stream - no byte[] copy, no MemoryStream
  private static IEnumerable<ProductDto> ReadCsvRecords(Stream stream)
  {
    using var reader = new StreamReader(stream, leaveOpen: true);
    using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
    {
      HeaderValidated = null,
      MissingFieldFound = null
    });

    foreach (var record in csv.GetRecords<ProductDto>())
      yield return record;
  }

  // ExcelDataReader reads row-by-row from stream - no full workbook in memory
  private IEnumerable<ProductDto> ReadExcelRecords(Stream stream)
  {
    // Required for .NET Core to handle extended encodings used by older Excel formats
    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

    using var reader = ExcelReaderFactory.CreateReader(stream);

    reader.Read(); // skip header row

    while (reader.Read())
    {
      yield return new ProductDto
      {
        Name = reader.GetString(0),
        Description = reader.GetString(1),
        Price = reader.IsDBNull(2) ? 0 : Convert.ToDecimal(reader.GetValue(2)),
        IsAvailable = !reader.IsDBNull(3) && reader.GetBoolean(3),
        Capacity = reader.GetString(4),
        CountryOfOrigin = reader.GetString(5),
        ProductType = reader.IsDBNull(6)
          ? default
          : (ProductType)Enum.Parse(typeof(ProductType), reader.GetString(6))
      };
    }
  }
}
