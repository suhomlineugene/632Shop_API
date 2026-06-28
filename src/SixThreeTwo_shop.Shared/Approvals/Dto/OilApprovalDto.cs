using Abp.Application.Services.Dto;
using SixThreeTwo_shop.Products;

namespace SixThreeTwo_shop.Shared.Approvals.Dto;

public class OilApprovalDto : EntityDto
{
  public string Name { get; set; }

  public string Description { get; set; }

  public StandardType StandardType { get; set; }
}

