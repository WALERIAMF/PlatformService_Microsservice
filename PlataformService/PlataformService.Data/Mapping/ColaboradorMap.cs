using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformService.Data.Entity;

namespace PlataformService.Data.Mapping
{
    public class ColaboradorMap : IEntityTypeConfiguration<ColaboradorEntity>
    {
        public void Configure(EntityTypeBuilder<ColaboradorEntity> builder)
        {
            builder.ToTable("Colaboradores");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(p => p.Email)
                    .HasMaxLength(50)
                    .IsRequired()
                    .HasColumnType("varchar");

            builder.Property(p => p.Cpf)
                    .HasPrecision(11)
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
