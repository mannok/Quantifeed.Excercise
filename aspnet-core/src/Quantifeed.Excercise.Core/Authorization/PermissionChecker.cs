using Abp.Authorization;
using Quantifeed.Excercise.Authorization.Roles;
using Quantifeed.Excercise.Authorization.Users;

namespace Quantifeed.Excercise.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
