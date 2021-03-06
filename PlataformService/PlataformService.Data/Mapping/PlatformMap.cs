using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformService.Data.Entity;
using PlataformService.Domain.Model;

namespace PlataformService.Data.Mapping
{
    public class PlatformMap : IEntityTypeConfiguration<PlatformEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformEntity> builder)
        {
            builder.ToTable("Platforms");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(p => p.Publisher)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(p => p.Cost)
                .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.DataCriacao)
                  .HasColumnType("datetime2")
                  .HasPrecision(0);

            builder.Property(p => p.DataAtualizacao)
                .HasColumnType("datetime2")
                .HasPrecision(0);

        }
    }
}
