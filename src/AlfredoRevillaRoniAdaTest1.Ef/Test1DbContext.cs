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

        public DbSet<RoomTypeRepositoryModel> RoomTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<JobRepositoryModel>()
                .ToTable("RX_Job")
                ;

            modelBuilder
             .Entity<RoomTypeRepositoryModel>()
             .ToTable("RX_RoomType")
             ;

            base.OnModelCreating(modelBuilder);
        }
    }
}