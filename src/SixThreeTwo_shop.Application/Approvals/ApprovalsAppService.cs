using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Approvals;
using SixThreeTwo_shop.Shared.Approvals.Dto;

namespace SixThreeTwo_shop.Approvals;

public class ApprovalsAppService(
  IRepository<OilApproval> oilApprovalRepository)
  : SixThreeTwo_shopAppServiceBase, IApprovalsAppService
{
  #region OilApprovals

  public async Task<List<OilApprovalDto>> GetAllOilApprovals()
  {
    var oilApprovals = await oilApprovalRepository.GetAllListAsync();
    return ObjectMapper.Map<List<OilApprovalDto>>(oilApprovals);
  }

  public async Task<OilApprovalDto> GetOilApprovalById(int id)
  {
    var oilApproval = await oilApprovalRepository.GetAsync(id);
    return ObjectMapper.Map<OilApprovalDto>(oilApproval);
  }

  public async Task<int> CreateOrEditOilApproval(CreateEditOilApprovalDto oilApprovalDto)
  {
    if (oilApprovalDto.Id == 0)
    {
      var oilApproval = ObjectMapper.Map<OilApproval>(oilApprovalDto);
      var id = await oilApprovalRepository.InsertAndGetIdAsync(oilApproval);
      return id;
    }
    else
    {
      var oilApproval = await oilApprovalRepository.GetAsync(oilApprovalDto.Id);
      ObjectMapper.Map(oilApprovalDto, oilApproval);
      await oilApprovalRepository.UpdateAsync(oilApproval);
      return oilApproval.Id;
    }
  }

  public async Task DeleteOilApproval(int id)
  {
    await oilApprovalRepository.DeleteAsync(id);
  }

  public List<StandardTypeDropdownDto> GetStandardTypeDropdown()
  {
    return Enum.GetValues<StandardType>()
      .Select(st => new StandardTypeDropdownDto { Id = (int)st, Name = st.ToString() })
      .ToList();
  }

  #endregion
}

