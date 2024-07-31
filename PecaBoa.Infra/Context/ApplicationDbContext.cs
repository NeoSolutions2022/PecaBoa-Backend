using System.Reflection;
using FluentValidation.Results;
using PecaBoa.Core.Authorization;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Converters;
using PecaBoa.Infra.Extensions;

namespace PecaBoa.Infra.Context;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IAuthenticatedUser _authenticatedUser;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAuthenticatedUser authenticatedUser) : base(options)
    {
        _authenticatedUser = authenticatedUser;
    }
    
    public DbSet<Administrador> Administradores { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Lojista> Lojistas { get; set; } = null!;
    public DbSet<Pedido> Pedidos { get; set; } = null!;
    public DbSet<Orcamento> Orcamentos { get; set; } = null!;
    public DbSet<Status> Status { get; set; } = null!;
    public DbSet<TipoDePeca> TipoDePecas { get; set; } = null!;
    public DbSet<CondicaoPeca> CondicaoPecas { get; set; } = null!;
    public DbSet<CategoriaVeiculo> CategoriaVeiculos { get; set; } = null!;
    public DbSet<Marca> Marcas { get; set; } = null!;
    public DbSet<Modelo> Modelos { get; set; } = null!;
    public DbSet<GrupoAcesso> GruposAcesso { get; set; } = null!;
    public DbSet<Permissao> Permissoes { get; set; } = null!;
    public DbSet<Inscricao> Inscricoes { get; set; } = null!;
    public DbSet<LojistaCartaoDeCredito> LojistaCartoesDeCredito { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        ApplyConfiguration(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (_authenticatedUser.UsuarioAdministrador)
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