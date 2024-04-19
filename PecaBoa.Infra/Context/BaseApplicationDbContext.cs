using System.Reflection;
using FluentValidation.Results;
using PecaBoa.Core.Authorization;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Converters;

namespace PecaBoa.Infra.Context;

public abstract class BaseApplicationDbContext : DbContext, IUnitOfWork
{
    protected readonly IAuthenticatedUser AuthenticatedUser;
    protected BaseApplicationDbContext() { }
    protected BaseApplicationDbContext(DbContextOptions options ,IAuthenticatedUser authenticatedUser) : base(options)
    {
        AuthenticatedUser = authenticatedUser;
    }

    public DbSet<Administrador> Administradores { get; set; } = null!;
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Fornecedor> Fornecedores { get; set; } = null!;
    public DbSet<ProdutoServico> ProdutoServicos { get; set; } = null!;
    public DbSet<ProdutoServicoCaracteristica> ProdutoServicoCaracteristicas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        ApplyConfiguration(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (AuthenticatedUser.UsuarioAdministrador)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> Commit() => await SaveChangesAsync() > 0;

        private static void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyEntityConfiguration();
            // modelBuilder.ApplyTrackingConfiguration();
            modelBuilder.ApplySoftDeleteConfiguration();
        }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateOnly>()
            .HaveConversion<DateOnlyCustomConverter>()
            .HaveColumnType("DATE");

        configurationBuilder 
            .Properties<TimeOnly>()
            .HaveConversion<TimeOnlyCustomConverter>()
            .HaveColumnType("TIME");
    }
}