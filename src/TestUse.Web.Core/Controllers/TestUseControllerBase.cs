using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TestUse.Controllers
{
    public abstract class TestUseControllerBase: AbpController
    {
        protected TestUseControllerBase()
        {
            LocalizationSourceName = TestUseConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
