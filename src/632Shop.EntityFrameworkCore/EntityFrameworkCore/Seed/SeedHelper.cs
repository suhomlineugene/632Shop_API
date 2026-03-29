using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using 632Shop.EntityFrameworkCore.Seed.Host;
using 632Shop.EntityFrameworkCore.Seed.Tenants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;

namespace 632Shop.EntityFrameworkCore.Seed;

public static class SeedHelper
{
    public static void SeedHostDb(IIocResolver iocResolver)
    {
        WithDbContext<632ShopDbContext>(iocResolver, SeedHostDb);
    }

    public static void SeedHostDb(632ShopDbContext context)
    {
        context.SuppressAutoSetTenantId = true;

        // Host seed
        new InitialHostDbBuilder(context).Create();

        // Default tenant seed (in host database).
        new DefaultTenantBuilder(context).Create();
        new TenantRoleAndUserBuilder(context, 1).Create();
    }

    private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
        where TDbContext : DbContext
    {
        using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
        {
            using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
            {
                var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                contextAction(context);

                uow.Complete();
            }
        }
    }
}
