using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace 632Shop.EntityFrameworkCore.Repositories;

/// <summary>
/// Base class for custom repositories of the application.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
/// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
public abstract class 632ShopRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<632ShopDbContext, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    protected 632ShopRepositoryBase(IDbContextProvider<632ShopDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    // Add your common methods for all repositories
}

/// <summary>
/// Base class for custom repositories of the application.
/// This is a shortcut of <see cref="632ShopRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
public abstract class 632ShopRepositoryBase<TEntity> : 632ShopRepositoryBase<TEntity, int>, IRepository<TEntity>
    where TEntity : class, IEntity<int>
{
    protected 632ShopRepositoryBase(IDbContextProvider<632ShopDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    // Do not add any method here, add to the class above (since this inherits it)!!!
}
