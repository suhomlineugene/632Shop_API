using AutoMapper;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Approvals.Dto;

namespace SixThreeTwo_shop.Mapping;

public class ApprovalsMapProfile : Profile
{
    public ApprovalsMapProfile()
    {
        CreateMap<OilApproval, OilApprovalDto>();

        CreateMap<OilApprovalDto, OilApproval>();

        CreateMap<OilApproval, CreateEditOilApprovalDto>();

        CreateMap<CreateEditOilApprovalDto, OilApproval>();
    }
}

