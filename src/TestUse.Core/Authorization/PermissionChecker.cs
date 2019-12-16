using Abp.Authorization;
using TestUse.Authorization.Roles;
using TestUse.Authorization.Users;

namespace TestUse.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
