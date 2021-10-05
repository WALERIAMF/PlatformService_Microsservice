using Microsoft.EntityFrameworkCore;
using PlataformService.Data.Entity;
using PlataformService.Data.Mapping;

namespace PlataformService.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<PlatformEntity> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity Configurations
            modelBuilder.ApplyConfiguration(new PlatformMap());
        }
    }
}
