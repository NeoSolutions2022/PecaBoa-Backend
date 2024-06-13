using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class ModeloMap : IEntityTypeConfiguration<Modelo>
{
    public void Configure(EntityTypeBuilder<Modelo> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(250)
            .IsRequired();

        builder
            .HasOne(c => c.Marca)
            .WithMany(c => c.Modelos)
            .HasForeignKey(c => c.MarcaId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}