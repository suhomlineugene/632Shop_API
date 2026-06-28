using Abp.Application.Services;
using SixThreeTwo_shop.Shared.Approvals.Dto;

namespace SixThreeTwo_shop.Shared.Approvals;

public interface IApprovalsAppService: IApplicationService
{
  #region OilApprovals
  
  Task<List<OilApprovalDto>> GetAllOilApprovals();
  
  Task<OilApprovalDto> GetOilApprovalById(int id);
  
  Task<int> CreateOrEditOilApproval(CreateEditOilApprovalDto oilApprovalDto);
  
  Task DeleteOilApproval(int id);

  List<StandardTypeDropdownDto> GetStandardTypeDropdown();
  
  #endregion

  #region ManufacturerApprovals

  Task<List<ManufacturerApprovalDto>> GetAllManufacturerApprovals();

  Task<ManufacturerApprovalDto> GetManufacturerApprovalById(int id);

  Task<int> CreateOrEditManufacturerApproval(CreateEditManufacturerApprovalDto manufacturerApprovalDto);

  Task DeleteManufacturerApproval(int id);

  #endregion
}
