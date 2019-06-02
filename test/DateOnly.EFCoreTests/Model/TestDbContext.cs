using Microsoft.EntityFrameworkCore;

namespace mdsharpe.DateOnly.EFCoreTests.Model {
    public class TestDbContext : DbContext {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
