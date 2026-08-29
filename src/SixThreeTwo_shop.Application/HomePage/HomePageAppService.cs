using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using SixThreeTwo_shop.Common;
using SixThreeTwo_shop.Shared.Common;
using SixThreeTwo_shop.Shared.HomePage;
using SixThreeTwo_shop.Shared.HomePage.Dto;

namespace SixThreeTwo_shop.HomePage;

public class HomePageAppService(
  IRepository<MainBanner> mainBannerRepository,
  IS3Uploader s3Uploader,
  IConfiguration configuration)
  : ApplicationService, IHomePageAppService
{
  private const string BannerImagesFolder = "banner-images";
  private readonly string _imagesBaseUrl = configuration
    .GetSection(AwsS3Settings.SectionName)
    .Get<AwsS3Settings>()?.ImagesBaseUrl ?? string.Empty;

  public async Task<List<MainBannerDto>> GetAllMainBannersAsync()
  {
    var mainBanners = await mainBannerRepository.GetAllListAsync();
    var result = ObjectMapper.Map<List<MainBannerDto>>(mainBanners);

    foreach (var banner in result)
    {
      banner.ToPublicImageUrl(_imagesBaseUrl);
    }

    return result;
  }
  
  public async Task<MainBannerDto> GetMainBannerAsync()
  {
    var mainBanner = await mainBannerRepository.FirstOrDefaultAsync(x => x.IsActive);
    var result = ObjectMapper.Map<MainBannerDto>(mainBanner);
    return result.ToPublicImageUrl(_imagesBaseUrl);
  }

  public async Task<MainBannerDto> CreateEditMainBannerAsync(CreateEditMainBanner input)
  {
    MainBanner mainBanner;

    if (input.Id == 0)
    {
      mainBanner = ObjectMapper.Map<MainBanner>(input);
      mainBanner.IsActive = true;

      if (input.Image != null)
      {
        mainBanner.ImageUrl = await s3Uploader.UploadFileAsync(input.Image, BannerImagesFolder);
      }

      mainBanner = await mainBannerRepository.InsertAsync(mainBanner);
    }
    else
    {
      mainBanner = await mainBannerRepository.GetAsync(input.Id);
      ObjectMapper.Map(input, mainBanner);

      if (input.Image != null)
      {
        if (!string.IsNullOrWhiteSpace(mainBanner.ImageUrl))
        {
          await s3Uploader.DeleteFileAsync(mainBanner.ImageUrl);
        }

        mainBanner.ImageUrl = await s3Uploader.UploadFileAsync(input.Image, BannerImagesFolder);
      }

      await mainBannerRepository.UpdateAsync(mainBanner);
    }

    return ObjectMapper.Map<MainBannerDto>(mainBanner).ToPublicImageUrl(_imagesBaseUrl);
  }

  public async Task DeleteMainBannerAsync(MainBannerDto input)
  {
    var mainBanner = await mainBannerRepository.GetAsync(input.Id);

    if (!string.IsNullOrWhiteSpace(mainBanner.ImageUrl))
    {
      await s3Uploader.DeleteFileAsync(mainBanner.ImageUrl);
    }

    await mainBannerRepository.DeleteAsync(input.Id);
  }
}


