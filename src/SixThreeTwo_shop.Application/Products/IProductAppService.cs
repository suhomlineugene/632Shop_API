using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SixThreeTwo_shop.Products.Dto;

namespace SixThreeTwo_shop.Products;

public interface IProductAppService : IApplicationService
{
    Task<PagedResultDto<ProductDto>> GetAllAsync(GetAllProductsInput input);

    Task CreateOrEditAsync(CreateOrEditProductDto input);

    Task DeleteAsync(EntityDto input);
}

