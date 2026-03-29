using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace SixThreeTwo_shop.EntityFrameworkCore;

public static class SixThreeTwo_shopDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<SixThreeTwo_shopDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<SixThreeTwo_shopDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
