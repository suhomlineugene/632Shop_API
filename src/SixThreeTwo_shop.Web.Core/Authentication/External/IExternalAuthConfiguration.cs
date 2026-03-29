using System.Collections.Generic;

namespace SixThreeTwo_shop.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
