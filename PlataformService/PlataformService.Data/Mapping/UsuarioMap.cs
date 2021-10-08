using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformService.Data.Entity;

namespace PlataformService.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
      
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(p => p.Login)
                    .HasMaxLength(10)
                    .IsRequired()
                    .HasColumnType("varchar");

            builder.Property(p => p.Senha)
                    .HasMaxLength(12)
                    .IsRequired()
                    .HasColumnType("varchar");

            builder.Property(p => p.DataCriacao)
                      .HasColumnType("datetime2")
                      .HasPrecision(0);

            builder.Property(p => p.DataAtualizacao)
                    .HasColumnType("datetime2")
                    .HasPrecision(0);
        }
    }
}
