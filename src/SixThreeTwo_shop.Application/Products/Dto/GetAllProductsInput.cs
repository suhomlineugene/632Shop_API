using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Products.Dto;

public class GetAllProductsInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// Optional keyword to filter by Name, Sku, or Brand.
    /// </summary>
    public string Filter { get; set; }

    /// <summary>
    /// Optional filter by published state.
    /// </summary>
    public bool? IsPublished { get; set; }
}

