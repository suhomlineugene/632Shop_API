using System.ComponentModel.DataAnnotations;

namespace SixThreeTwo_shop.Products.Dto;

public class CreateOrEditProductDto
{
    /// <summary>
    /// Null for create, set to product Id for edit.
    /// </summary>
    public int? Id { get; set; }

    [Required]
    [MaxLength(256)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Sku { get; set; }

    [Required]
    [MaxLength(300)]
    public string Slug { get; set; }

    public string Description { get; set; }

    [MaxLength(256)]
    public string Brand { get; set; }

    [MaxLength(100)]
    public string OilType { get; set; }

    [MaxLength(50)]
    public string ViscosityGrade { get; set; }

    [MaxLength(100)]
    public string ApiStandard { get; set; }

    public decimal ContainerSize { get; set; }

    public decimal Price { get; set; }

    public int StockQuality { get; set; }

    public bool IsPublished { get; set; }
}

