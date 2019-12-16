using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TestUse.Configuration;
using TestUse.Web;

namespace TestUse.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TestUseDbContextFactory : IDesignTimeDbContextFactory<TestUseDbContext>
    {
        public TestUseDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestUseDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TestUseDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TestUseConsts.ConnectionStringName));

            return new TestUseDbContext(builder.Options);
        }
    }
}
