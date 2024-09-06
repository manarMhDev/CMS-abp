using Abp.Authorization;
using CMS.Manar.Authorization.Roles;
using CMS.Manar.Authorization.Users;

namespace CMS.Manar.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
