using Abp.AutoMapper;
using Quantifeed.Excercise.Authentication.External;

namespace Quantifeed.Excercise.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
