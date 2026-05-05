using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Authorization;
using SixThreeTwo_shop.Products.Dto;

namespace SixThreeTwo_shop.Products;

[AbpAuthorize(PermissionNames.Pages_Products)]
public class ProductAppService(
    IRepository<Product> productRepository,
    IMapper mapper)
    : SixThreeTwo_shopAppServiceBase, IProductAppService
{
    public async Task<PagedResultDto<ProductDto>> GetAllAsync(GetAllProductsInput input)
    {
        var query = (await productRepository.GetAllAsync())
            .WhereIf(!input.Filter.IsNullOrWhiteSpace(), p =>
                p.Name.Contains(input.Filter) ||
                p.Sku.Contains(input.Filter) ||
                p.Brand.Contains(input.Filter))
            .WhereIf(input.IsPublished.HasValue, p => p.IsPublished == input.IsPublished.Value);

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount)
            .ToListAsync();

        return new PagedResultDto<ProductDto>(
            totalCount,
            mapper.Map<System.Collections.Generic.List<ProductDto>>(items));
    }

    public async Task CreateOrEditAsync(CreateOrEditProductDto input)
    {
        if (input.Id == null || input.Id == 0)
        {
            await CreateProductAsync(input);
        }
        else
        {
            await EditProductAsync(input);
        }
    }

    public async Task DeleteAsync(EntityDto input)
    {
        var product = await productRepository.FirstOrDefaultAsync(input.Id);
        if (product == null)
        {
            throw new UserFriendlyException($"Product with Id {input.Id} was not found.");
        }

        await productRepository.DeleteAsync(product);
    }

    private async Task CreateProductAsync(CreateOrEditProductDto input)
    {
        var product = mapper.Map<Product>(input);
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;

        await productRepository.InsertAsync(product);
    }

    private async Task EditProductAsync(CreateOrEditProductDto input)
    {
        var product = await productRepository.FirstOrDefaultAsync(input.Id!.Value);
        if (product == null)
        {
            throw new UserFriendlyException($"Product with Id {input.Id} was not found.");
        }

        mapper.Map(input, product);
        product.UpdatedAt = DateTime.UtcNow;

        await productRepository.UpdateAsync(product);
    }
}


