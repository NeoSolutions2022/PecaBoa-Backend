﻿using PecaBoa.Core.Authorization;
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

        service.AddDbContext<ApplicationDbContext>(optionsAction =>
        {
            optionsAction.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsAction.EnableDetailedErrors();
            optionsAction.EnableSensitiveDataLogging();
        });
        
        service.AddScoped<BaseApplicationDbContext>(serviceProvider =>
        {
            return serviceProvider.GetRequiredService<ApplicationDbContext>();
        });
    }

    public static void ConfigureRepositories(this IServiceCollection service)
    {
        service
            .AddScoped<IUsuarioRepository,UsuarioRepository>()
            .AddScoped<IFornecedorRepository, FornecedorRepository>()
            .AddScoped<IAdministradorRepository, AdministradorRepository>()
            .AddScoped<IProdutoServicoCaracteristicaRepository, ProdutoServicoCaracteristicaRepository>()
            .AddScoped<IProdutoServicoRepository, ProdutoServicoRepository>();
    }

    public static void UseMigrations(this IApplicationBuilder app, IServiceProvider service)
    {
        using var scope = service.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}