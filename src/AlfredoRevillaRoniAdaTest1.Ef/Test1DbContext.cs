using AlfredoRevillaRoniAdaTest1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlfredoRevillaRoniAdaTest1.Ef
{
    public class Test1DbContext : DbContext
    {
        public Test1DbContext(DbContextOptions<Test1DbContext> options) : base(options)
        {
        }

        public DbSet<JobRepositoryModel> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<JobRepositoryModel>()
                .ToTable("RX_Job")
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}