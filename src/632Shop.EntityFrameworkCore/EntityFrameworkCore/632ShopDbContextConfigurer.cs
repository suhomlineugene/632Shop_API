using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace 632Shop.EntityFrameworkCore;

public static class 632ShopDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<632ShopDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<632ShopDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
