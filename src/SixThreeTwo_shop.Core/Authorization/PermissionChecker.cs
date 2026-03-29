using Abp.Authorization;
using SixThreeTwo_shop.Authorization.Roles;
using SixThreeTwo_shop.Authorization.Users;

namespace SixThreeTwo_shop.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
