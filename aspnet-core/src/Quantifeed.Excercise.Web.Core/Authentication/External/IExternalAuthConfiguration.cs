using System.Collections.Generic;

namespace Quantifeed.Excercise.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
