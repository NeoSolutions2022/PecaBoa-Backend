using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class CategoriaVeiculoMap : IEntityTypeConfiguration<CategoriaVeiculo>
{
    public void Configure(EntityTypeBuilder<CategoriaVeiculo> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(250)
            .IsRequired();
    }
}