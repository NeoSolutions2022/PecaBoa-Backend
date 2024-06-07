using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class CondicaoPecaMap : IEntityTypeConfiguration<CondicaoPeca>
{
    public void Configure(EntityTypeBuilder<CondicaoPeca> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(250)
            .IsRequired();
    }
}