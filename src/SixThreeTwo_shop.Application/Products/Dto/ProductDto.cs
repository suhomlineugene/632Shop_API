using System;
using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Products.Dto;

public class ProductDto : EntityDto
{
    public string Name { get; set; }

    public string Sku { get; set; }

    public string Slug { get; set; }

    public string Description { get; set; }

    public string Brand { get; set; }

    public string OilType { get; set; }

    public string ViscosityGrade { get; set; }

    public string ApiStandard { get; set; }

    public decimal ContainerSize { get; set; }

    public decimal Price { get; set; }

    public int StockQuality { get; set; }

    public bool IsPublished { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}

