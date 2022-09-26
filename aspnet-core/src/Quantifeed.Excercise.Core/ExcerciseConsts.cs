using Quantifeed.Excercise.Debugging;

namespace Quantifeed.Excercise
{
    public class ExcerciseConsts
    {
        public const string LocalizationSourceName = "Excercise";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "3f498d2dc529424bae33f01b0a456aa4";
    }
}
