using API_Entrance.Core.Entities.Concrete;
using API_Entrance.DataAccess.SeedData;
using Microsoft.EntityFrameworkCore;

namespace API_Entrance.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new TaskItemSeedData());
        }
    }
}
