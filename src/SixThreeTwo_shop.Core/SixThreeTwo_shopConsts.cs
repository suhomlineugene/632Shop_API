using SixThreeTwo_shop.Debugging;

namespace SixThreeTwo_shop;

public class SixThreeTwo_shopConsts
{
    public const string LocalizationSourceName = "SixThreeTwo_shop";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "dd1bc2954f0a420a9851f4f7c7878402";
}
