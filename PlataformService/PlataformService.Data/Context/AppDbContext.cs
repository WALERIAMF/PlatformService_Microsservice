using Microsoft.EntityFrameworkCore;
using PlataformService.Data.Entity;
using PlataformService.Data.Mapping;

namespace PlataformService.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ColaboradorEntity> Colaboradores { get; set; }
        public DbSet<GrupoPermissaoEntity> GrupoPermissoes { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }
        public DbSet<PermissaoEntity> Permissoes { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity Configurations
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new GrupoPermissaoMap());
            modelBuilder.ApplyConfiguration(new PlatformMap());
            modelBuilder.ApplyConfiguration(new PermissaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

        }
    }
}
