using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
{
    public void Configure(EntityTypeBuilder<Orcamento> builder)
    {
        builder.Property(c => c.Observacoes)
            .HasMaxLength(1500)
            .IsRequired();

        builder.Property(c => c.PrazoDeEntrega)
            .HasColumnType("date")
            .IsRequired();
        
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
            .HasOne(c => c.Pedido)
            .WithMany(c => c.Orcamentos)
            .HasForeignKey(c => c.PedidoId);
    }
}