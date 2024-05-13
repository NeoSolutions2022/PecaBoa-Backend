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

        builder.Property(c => c.DataDeEntrega)
            .HasColumnType("date")
            .IsRequired();

        builder
            .HasOne(c => c.Pedido)
            .WithMany(c => c.Orcamentos)
            .HasForeignKey(c => c.PedidoId);

        builder
            .HasOne(c => c.Usuario)
            .WithMany(c => c.Orcamentos)
            .HasForeignKey(c => c.UsuarioId);
    }
}