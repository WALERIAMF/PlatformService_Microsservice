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
                .HasColumnType("decimal(5, 2)");
        }
    }
}
