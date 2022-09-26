using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Quantifeed.Excercise.Controllers
{
    public abstract class ExcerciseControllerBase: AbpController
    {
        protected ExcerciseControllerBase()
        {
            LocalizationSourceName = ExcerciseConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
