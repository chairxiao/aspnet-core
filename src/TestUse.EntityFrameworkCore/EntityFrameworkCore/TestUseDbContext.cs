using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TestUse.Authorization.Roles;
using TestUse.Authorization.Users;
using TestUse.MultiTenancy;
using TestUse.Products;

namespace TestUse.EntityFrameworkCore
{
    public class TestUseDbContext : AbpZeroDbContext<Tenant, Role, User, TestUseDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public TestUseDbContext(DbContextOptions<TestUseDbContext> options)
            : base(options)
        {
        }
    }
}
