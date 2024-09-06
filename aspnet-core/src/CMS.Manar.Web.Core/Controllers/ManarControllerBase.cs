using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CMS.Manar.Controllers
{
    public abstract class ManarControllerBase: AbpController
    {
        protected ManarControllerBase()
        {
            LocalizationSourceName = ManarConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
