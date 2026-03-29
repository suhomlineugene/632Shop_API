using Abp.Authorization.Roles;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using 632Shop.Authorization.Users;

namespace 632Shop.Authorization.Roles;

public class RoleStore : AbpRoleStore<Role, User>
{
    public RoleStore(
        IUnitOfWorkManager unitOfWorkManager,
        IRepository<Role> roleRepository,
        IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
        : base(
            unitOfWorkManager,
            roleRepository,
            rolePermissionSettingRepository)
    {
    }
}
