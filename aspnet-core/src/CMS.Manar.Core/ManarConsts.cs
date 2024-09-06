using CMS.Manar.Debugging;

namespace CMS.Manar
{
    public class ManarConsts
    {
        public const string LocalizationSourceName = "Manar";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "71f44a3b3cd64860a71ca47f79d010b2";
    }
}
