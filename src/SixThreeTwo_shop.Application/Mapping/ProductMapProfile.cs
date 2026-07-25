using AutoMapper;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Products.Dto;

namespace SixThreeTwo_shop.Mapping;

public class ProductMapProfile : Profile
{
    public ProductMapProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(x => x.Viscosity, opt => opt.MapFrom(p => p.MotorOil != null ? p.MotorOil.Viscosity : null))
            .ForMember(x => x.CoolantApproval, opt => opt.MapFrom(p => p.Coolant != null ? p.Coolant.Approval : null))
            .ForMember(x => x.TransmissionViscosity, opt => opt.MapFrom(p => p.TransmissionFluid != null ? p.TransmissionFluid.Viscosity : null))
            .ForMember(x => x.AdditiveType, opt => opt.MapFrom(p => p.Additive != null ? p.Additive.AdditiveType : null))
            .ForMember(x => x.TransmissionType, opt => opt.MapFrom(p => p.TransmissionFluid != null ? p.TransmissionFluid.TransmissionType : default))
            .ForMember(x => x.StockQuantity, opt => opt.MapFrom(p =>
                p.MotorOil != null ? p.MotorOil.StockQuantity :
                p.Coolant != null ? p.Coolant.StockQuantity :
                p.TransmissionFluid != null ? p.TransmissionFluid.StockQuantity :
                p.Additive != null ? p.Additive.StockQuantity : 0));
        
        CreateMap<ProductDto, Product>()
            .ForMember(x => x.CreationTime, opt => opt.Ignore())
            .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
            .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
            .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.DeletionTime, opt => opt.Ignore())
            .ForMember(x => x.DeleterUserId, opt => opt.Ignore());

        CreateMap<Product, CreateEditProductDto>()
            .ForMember(x => x.Viscosity, opt => opt.MapFrom(p => p.MotorOil != null ? p.MotorOil.Viscosity : null))
            .ForMember(x => x.CoolantApproval, opt => opt.MapFrom(p => p.Coolant != null ? p.Coolant.Approval : null))
            .ForMember(x => x.TransmissionViscosity, opt => opt.MapFrom(p => p.TransmissionFluid != null ? p.TransmissionFluid.Viscosity : null))
            .ForMember(x => x.AdditiveType, opt => opt.MapFrom(p => p.Additive != null ? p.Additive.AdditiveType : null))
            .ForMember(x => x.TransmissionType, opt => opt.MapFrom(p => p.TransmissionFluid != null ? p.TransmissionFluid.TransmissionType : default))
            .ForMember(x => x.StockQuantity, opt => opt.MapFrom(p =>
                p.MotorOil != null ? p.MotorOil.StockQuantity :
                p.Coolant != null ? p.Coolant.StockQuantity :
                p.TransmissionFluid != null ? p.TransmissionFluid.StockQuantity :
                p.Additive != null ? p.Additive.StockQuantity : 0));

        CreateMap<CreateEditProductDto, Product>()
            .ForMember(x => x.CreationTime, opt => opt.Ignore())
            .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
            .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
            .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.DeletionTime, opt => opt.Ignore())
            .ForMember(x => x.ProductImages, opt => opt.Ignore())
            .ForMember(x => x.DeleterUserId, opt => opt.Ignore());
    }
}
