using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SixThreeTwo_shop.Localization;

public static class SixThreeTwo_shopLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(SixThreeTwo_shopConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(SixThreeTwo_shopLocalizationConfigurer).GetAssembly(),
                    "SixThreeTwo_shop.Localization.SourceFiles"
                )
            )
        );
    }
}
