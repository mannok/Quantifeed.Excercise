using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Quantifeed.Excercise.Localization
{
    public static class ExcerciseLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ExcerciseConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ExcerciseLocalizationConfigurer).GetAssembly(),
                        "Quantifeed.Excercise.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
