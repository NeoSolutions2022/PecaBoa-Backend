using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Infra.Mappings;

public class StatusMap : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.Property(c => c.Nome)
            .HasMaxLength(250)
            .IsRequired();
    }
}