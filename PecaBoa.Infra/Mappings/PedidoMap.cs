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

        builder.Property(c => c.AnoDeFabricacao)
            .HasColumnType("date")
            .IsRequired(false);
        
        builder.Property(c => c.Cor)
            .HasMaxLength(180)
            .IsRequired();

        builder.Property(c => c.StatusId)
            .IsRequired();

        builder.Property(c => c.DataFim)
            .HasColumnType("timestamp");

        builder.Property(c => c.DataLimite)
            .HasColumnType("timestamp");

        builder
            .HasOne(c => c.Status)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(c => c.StatusId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.Marca)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(c => c.MarcaId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(c => c.TipoDePeca)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(c => c.TipoDePecaId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(c => c.Modelo)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(c => c.ModeloId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(c => c.CategoriaVeiculo)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(c => c.CategoriaVeiculoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}