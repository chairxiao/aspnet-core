using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TestUse.EntityFrameworkCore
{
    public static class TestUseDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TestUseDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TestUseDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
