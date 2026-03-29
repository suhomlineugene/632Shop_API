using Abp.Zero.EntityFrameworkCore;
using 632Shop.Authorization.Roles;
using 632Shop.Authorization.Users;
using 632Shop.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace 632Shop.EntityFrameworkCore;

public class 632ShopDbContext : AbpZeroDbContext<Tenant, Role, User, 632ShopDbContext>
{
    /* Define a DbSet for each entity of the application */

    public 632ShopDbContext(DbContextOptions<632ShopDbContext> options)
        : base(options)
    {
    }
}
