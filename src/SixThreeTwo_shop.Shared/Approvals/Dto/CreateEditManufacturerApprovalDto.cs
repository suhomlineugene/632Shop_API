using Abp.Application.Services.Dto;

namespace SixThreeTwo_shop.Shared.Approvals.Dto;

public class CreateEditManufacturerApprovalDto : EntityDto
{
  public string Name { get; set; }

  public string Description { get; set; }

  public string ManufacturerName { get; set; }
}

