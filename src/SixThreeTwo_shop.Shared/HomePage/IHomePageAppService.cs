using Abp.Application.Services;
using SixThreeTwo_shop.Shared.HomePage.Dto;

namespace SixThreeTwo_shop.Shared.HomePage;

public interface IHomePageAppService : IApplicationService
{
  Task<MainBannerDto> GetMainBannerAsync();
  
  Task<MainBannerDto> CreateEditMainBannerAsync(CreateEditMainBanner input);
  
  Task DeleteMainBannerAsync(MainBannerDto input);
}
