using SixThreeTwo_shop.Shared.EngineOils.Dto;
using SixThreeTwo_shop.Shared.HomePage.Dto;

namespace SixThreeTwo_shop.Shared.Common;

public static class ImageHelper
{
    public static string ToPublicUrl(this string key, string baseUrl)
    {
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        return string.IsNullOrEmpty(baseUrl) ? key : $"{baseUrl.TrimEnd('/')}/{key.TrimStart('/')}";
    }

    public static MainBannerDto ToPublicImageUrl(this MainBannerDto dto, string baseUrl)
    {
        if (dto == null)
        {
            return null;
        }

        dto.ImageUrl = dto.ImageUrl.ToPublicUrl(baseUrl);
        return dto;
    }

    public static EngineOilDto ToPublicImageUrl(this EngineOilDto dto, string baseUrl)
    {
        if (dto == null)
        {
            return null;
        }

        dto.CoverImageUrl = dto.CoverImageUrl.ToPublicUrl(baseUrl);
        return dto;
    }
}