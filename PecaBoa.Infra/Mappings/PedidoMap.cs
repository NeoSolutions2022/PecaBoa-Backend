using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PecaBoa.Infra.Mappings;

public class PedidoMap : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.Property(c => c.NomePeca)
            .HasMaxLength(180)
            .IsRequired();

        builder.Property(c => c.Descricao)
            .IsRequired()
            .HasMaxLength(1500);

        builder.Property(c => c.Foto)
            .IsRequired(false)
            .HasMaxLength(1500);

        builder.Property(c => c.Foto2)
            .IsRequired(false)
            .HasMaxLength(1500);

        builder.Property(c => c.Foto3)
            .IsRequired(false)
            .HasMaxLength(1500);

        builder.Property(c => c.Foto4)
            .IsRequired(false)
            .HasMaxLength(1500);

        builder.Property(c => c.Foto5)
            .IsRequired(false)
            .HasMaxLength(1500);

        builder
            .Property(c => c.TipoDePeca)
            .HasMaxLength(250)
            .IsRequired();
        
        builder.Property(c => c.Marca)
            .HasMaxLength(180)
            .IsRequired();
        
        builder.Property(c => c.Modelo)
            .HasMaxLength(280)
            .IsRequired();

        builder.Property(c => c.AnoDeFabricacao)
            .HasColumnType("date")
            .IsRequired(false);
        
        builder.Property(c => c.Cor)
            .HasMaxLength(180)
            .IsRequired();
    }
}