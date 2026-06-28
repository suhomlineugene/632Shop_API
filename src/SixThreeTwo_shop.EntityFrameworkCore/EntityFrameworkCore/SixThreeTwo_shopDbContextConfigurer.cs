using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace SixThreeTwo_shop.EntityFrameworkCore;

public static class SixThreeTwo_shopDbContextConfigurer
{
  public static void Configure(DbContextOptionsBuilder<SixThreeTwo_shopDbContext> builder, string connectionString)
  {
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    builder.UseMySql(connectionString, serverVersion);
  }

  public static void Configure(DbContextOptionsBuilder<SixThreeTwo_shopDbContext> builder, DbConnection connection)
  {
    var serverVersion = ServerVersion.AutoDetect(connection.ConnectionString);
    builder.UseMySql(connection, serverVersion);
  }
}
