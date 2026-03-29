using SixThreeTwo_shop.Configuration;
using SixThreeTwo_shop.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SixThreeTwo_shop.EntityFrameworkCore;

/* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
public class SixThreeTwo_shopDbContextFactory : IDesignTimeDbContextFactory<SixThreeTwo_shopDbContext>
{
    public SixThreeTwo_shopDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SixThreeTwo_shopDbContext>();

        /*
         You can provide an environmentName parameter to the AppConfigurations.Get method. 
         In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
         Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
         https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
         */
        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        SixThreeTwo_shopDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SixThreeTwo_shopConsts.ConnectionStringName));

        return new SixThreeTwo_shopDbContext(builder.Options);
    }
}
