using 632Shop.Configuration;
using 632Shop.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace 632Shop.EntityFrameworkCore;

/* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
public class 632ShopDbContextFactory : IDesignTimeDbContextFactory<632ShopDbContext>
{
    public 632ShopDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<632ShopDbContext>();

        /*
         You can provide an environmentName parameter to the AppConfigurations.Get method. 
         In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
         Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
         https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
         */
        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        632ShopDbContextConfigurer.Configure(builder, configuration.GetConnectionString(632ShopConsts.ConnectionStringName));

        return new 632ShopDbContext(builder.Options);
    }
}
