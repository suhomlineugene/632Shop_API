using Abp.Zero.EntityFrameworkCore;
using SixThreeTwo_shop.Authorization.Roles;
using SixThreeTwo_shop.Authorization.Users;
using SixThreeTwo_shop.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace SixThreeTwo_shop.EntityFrameworkCore;

public class SixThreeTwo_shopDbContext : AbpZeroDbContext<Tenant, Role, User, SixThreeTwo_shopDbContext>
{
    /* Define a DbSet for each entity of the application */

    public SixThreeTwo_shopDbContext(DbContextOptions<SixThreeTwo_shopDbContext> options)
        : base(options)
    {
    }
}
