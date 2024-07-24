using PecaBoa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PecaBoa.Infra.Mappings;

public class LojistaMap : IEntityTypeConfiguration<Lojista>
{
    public void Configure(EntityTypeBuilder<Lojista> builder)
    {
        builder
            .Property(c => c.Bairro)
            .IsRequired()
            .HasMaxLength(30);

        
        builder
            .Property(c => c.Cep)
            .IsRequired()
            .HasMaxLength(9);
        
        builder.Property(c => c.Foto)
            .IsRequired(false)
            .HasMaxLength(1500);
        
        builder
            .Property(c => c.Cidade)
            .IsRequired()
            .HasMaxLength(60);
        
        builder
            .Property(c => c.Descricao)
            .IsRequired(false)
            .HasMaxLength(2000);
        
        builder
            .Property(c => c.Cnpj)
            .IsRequired()
            .HasMaxLength(14);
        
        
        builder
            .Property(c => c.Cpf)
            .IsRequired()
            .HasMaxLength(14);
        
        builder
            .Property(c => c.Desativado)
            .HasDefaultValue(false)
            .IsRequired();
        
        builder
            .Property(c => c.Email)
            .HasMaxLength(60)
            .IsRequired();
        
        builder
            .Property(c => c.Rua)
            .HasMaxLength(60)
            .IsRequired();
        
        builder
            .Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(60);
        
        builder
            .Property(c => c.Numero)
            .IsRequired();
        
        builder
            .Property(c => c.NomeFantasia)
            .IsRequired()
            .HasMaxLength(60);
        
        builder
            .Property(c => c.Senha)
            .IsRequired()
            .HasMaxLength(255);
        
        builder
            .Property(c => c.Telefone)
            .IsRequired(false)
            .HasMaxLength(17);
        
        builder
            .Property(c => c.Uf)
            .IsRequired()
            .HasMaxLength(2);

        builder
            .Property(c => c.CodigoResetarSenha)
            .HasColumnType("CHAR(64)")
            .IsRequired(false);
        
        builder
            .Property(c => c.CodigoResetarSenhaExpiraEm)
            .HasColumnType("date")
            .IsRequired(false);

        builder
            .HasMany(c => c.Orcamentos)
            .WithOne(c => c.Lojista)
            .HasForeignKey(c => c.LojistaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}