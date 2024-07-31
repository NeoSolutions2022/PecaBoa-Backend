using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class InscricaoMap : IEntityTypeConfiguration<Inscricao>
{
    public void Configure(EntityTypeBuilder<Inscricao> builder)
    {
        builder.Property(c => c.LojistaId)
            .IsRequired();
        
        builder.Property(c => c.EhRecorrente)
            .IsRequired();
        
        builder.Property(c => c.InscricaoAcabaEm)
            .HasColumnType("date")
            .IsRequired();
        
        builder
            .HasOne(c => c.Lojista)
            .WithOne(c => c.Inscricao)
            .HasForeignKey<Inscricao>(c => c.LojistaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}