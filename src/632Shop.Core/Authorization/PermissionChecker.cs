using Abp.Authorization;
using 632Shop.Authorization.Roles;
using 632Shop.Authorization.Users;

namespace 632Shop.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
