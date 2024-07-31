using PecaBoa.Core.Authorization;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PecaBoa.Infra.Context;
using PecaBoa.Infra.Repositories;

namespace PecaBoa.Infra;

public static class DependencyInjection
{
    public static void ConfigureDataBase(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddHttpContextAccessor();

        service.AddScoped<IAuthenticatedUser>(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

            return httpContextAccessor.UsuarioAutenticado()
                ? new AuthenticatedUser(httpContextAccessor)
                : new AuthenticatedUser();
        });

        service.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString!);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
    }

    public static void ConfigureRepositories(this IServiceCollection service)
    {
        service
            .AddScoped<ILojistaCartaoDeCreditoRepository, LojistaCartaoDeCreditoRepository>()
            .AddScoped<IInscricaoRepository, InscricaoRepository>()
            .AddScoped<IUsuarioRepository, UsuarioRepository>()
            .AddScoped<ILojistaRepository, LojistaRepository>()
            .AddScoped<IAdministradorRepository, AdministradorRepository>()
            .AddScoped<IPedidoRepository, PedidoRepository>()
            .AddScoped<IOrcamentoRepository, OrcamentoRepository>()
            .AddScoped<IStatusRepository, StatusRepository>()
            .AddScoped<ITipoDePecaRepository, TipoDePecaRepository>()
            .AddScoped<ICondicaoPecaRepository, CondicaoPecaRepository>()
            .AddScoped<ICategoriaVeiculoRepository, CategoriaVeiculoRepository>()
            .AddScoped<IMarcaRepository, MarcaRepository>()
            .AddScoped<IGrupoAcessoRepository, GrupoAcessoRepository>()
            .AddScoped<IPermissaoRepository, PermissaoRepository>()
            .AddScoped<IModeloRepository, ModeloRepository>();
    }

    public static void UseMigrations(this IApplicationBuilder app, IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}