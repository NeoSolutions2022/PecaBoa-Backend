using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PecaBoa.Infra.Mappings;

public class PedidoCaracteristicaMap : IEntityTypeConfiguration<PedidoCaracteristica>
{
    public void Configure(EntityTypeBuilder<PedidoCaracteristica> builder)
    {
        builder
            .Property(c => c.Chave)
            .HasMaxLength(50);
        
        builder
            .Property(c => c.Valor)
            .HasMaxLength(255);

        builder
            .HasOne(c => c.Pedido)
            .WithMany(c => c.PedidoCaracteristicas)
            .HasForeignKey(c => c.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}