using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class LojistaCartaoDeCreditoMapping : IEntityTypeConfiguration<LojistaCartaoDeCredito>
{
    public void Configure(EntityTypeBuilder<LojistaCartaoDeCredito> builder)
    {
        builder
            .Property(uc => uc.HolderName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(uc => uc.Number)
            .IsRequired()
            .HasMaxLength(255);
        
        builder
            .Property(uc => uc.LastNumbers)
            .IsRequired()
            .HasMaxLength(4);
        
        builder
            .Property(uc => uc.ExpiryMonth)
            .IsRequired()
            .HasMaxLength(2);
        
        builder
            .Property(uc => uc.ExpiryYear)
            .IsRequired()
            .HasMaxLength(4);
        
        builder
            .Property(uc => uc.Ccv)
            .IsRequired()
            .HasMaxLength(4);
        
        builder
            .Property(uc => uc.LojistaId)
            .IsRequired();

        builder
            .HasOne(uc => uc.Lojista)
            .WithMany(u => u.LojistaCartoesDeCredito)
            .HasForeignKey(uc => uc.LojistaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}