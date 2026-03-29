using 632Shop.Debugging;

namespace 632Shop;

public class 632ShopConsts
{
    public const string LocalizationSourceName = "632Shop";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "07ae7008fcb1464c9f04d546b0d7d424";
}
