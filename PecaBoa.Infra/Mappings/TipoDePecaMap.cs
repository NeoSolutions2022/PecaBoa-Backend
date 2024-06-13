using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class TipoDePecaMap : IEntityTypeConfiguration<TipoDePeca>
{
    public void Configure(EntityTypeBuilder<TipoDePeca> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(250)
            .IsRequired();
    }
}