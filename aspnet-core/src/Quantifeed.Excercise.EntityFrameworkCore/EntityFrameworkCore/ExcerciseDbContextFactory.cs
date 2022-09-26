using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Quantifeed.Excercise.Configuration;
using Quantifeed.Excercise.Web;

namespace Quantifeed.Excercise.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ExcerciseDbContextFactory : IDesignTimeDbContextFactory<ExcerciseDbContext>
    {
        public ExcerciseDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ExcerciseDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ExcerciseDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ExcerciseConsts.ConnectionStringName));

            return new ExcerciseDbContext(builder.Options);
        }
    }
}
