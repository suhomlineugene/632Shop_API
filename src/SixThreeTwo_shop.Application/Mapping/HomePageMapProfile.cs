using AutoMapper;
using SixThreeTwo_shop.HomePage;
using SixThreeTwo_shop.Shared.HomePage.Dto;

namespace SixThreeTwo_shop.Mapping;

public class HomePageMapProfile : Profile
{
  public HomePageMapProfile()
  {
    CreateMap<MainBanner, MainBannerDto>();

    CreateMap<CreateEditMainBanner, MainBanner>()
      .ForMember(x => x.ImageUrl, opt => opt.Ignore());
  }
}

