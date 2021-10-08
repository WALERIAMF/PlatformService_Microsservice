using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformService.Data.Entity;
using System;

namespace PlataformService.Data.Mapping
{
    public class PermissaoMap : IEntityTypeConfiguration<PermissaoEntity>
    {
        public void Configure(EntityTypeBuilder<PermissaoEntity> builder)
        {
            builder.ToTable("Permissoes");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");

            builder.Property(p => p.Descricao)
                    .HasMaxLength(100)
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
