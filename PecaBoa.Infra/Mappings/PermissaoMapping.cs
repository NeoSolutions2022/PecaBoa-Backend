using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class PermissaoMapping : IEntityTypeConfiguration<Permissao>
{
    public void Configure(EntityTypeBuilder<Permissao> builder)
    {
        builder
            .Property(e => e.Nome)
            .HasMaxLength(255)
            .IsRequired();
        
        builder
            .Property(c => c.Descricao)
            .IsRequired()
            .HasMaxLength(255);
        
        builder
            .Property(c => c.Categoria)
            .IsRequired()
            .HasMaxLength(255);
    }
}