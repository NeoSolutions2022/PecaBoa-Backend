using System.Reflection;
using PecaBoa.Application.BackgroundJob;
using PecaBoa.Application.Configuration.DependencyInjection;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Email;
using PecaBoa.Application.Notification;
using PecaBoa.Application.Services;
using PecaBoa.Core.Settings;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScottBrady91.AspNetCore.Identity;

namespace PecaBoa.Application;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.Configure<UploadSettings>(configuration.GetSection("UploadSettings"));

        services.ConfigureDataBase(configuration);
        services.ConfigureRepositories();

        services
            .AddEmailFactory(configuration);
        services
            .AddHangfireConfig(configuration);
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly());
    }
    
    public static void ConfigureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IUsuarioService, UsuarioService>()
            .AddScoped<ILojistaService, LojistaService>()
            .AddScoped<IBackgroundClient, BackgroundClient>()
            .AddScoped<IEmailService, EmailService>()
            .AddScoped<IAdministradorService, AdministradorService>();

        services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IPedidoService, PedidoService>()
            .AddScoped<IOrcamentoService, OrcamentoService>()
            .AddScoped<IPagamentosService, PagamentosService>()
            .AddScoped<IFileService, FileService>()
            .AddScoped<ILojistaAuthService, LojistaAuthService>()
            .AddScoped<IUsuarioAuthService, UsuarioAuthService>()
            .AddScoped<INotificator, Notificator>()
            .AddScoped<IPasswordHasher<Usuario>, Argon2PasswordHasher<Usuario>>()
            .AddScoped<IPasswordHasher<Lojista>, Argon2PasswordHasher<Lojista>>()
            .AddScoped<IPasswordHasher<Administrador>, Argon2PasswordHasher<Administrador>>();
    }
    
    // public static void UseStaticFileConfiguration(this IApplicationBuilder app, IConfiguration configuration)
    // {
    //     var uploadSettings = configuration.GetSection("UploadSettings");
    //     var publicBasePath = uploadSettings.GetValue<string>("PublicBasePath");
    //     var privateBasePath = uploadSettings.GetValue<string>("PrivateBasePath");
    //
    //     app.UseStaticFiles(new StaticFileOptions
    //     {
    //         FileProvider = new PhysicalFileProvider(publicBasePath),
    //         RequestPath = $"/{EPathAccess.Public.ToDescriptionString()}"
    //     });
    //
    //     app.UseStaticFiles(new StaticFileOptions
    //     {
    //         FileProvider = new PhysicalFileProvider(privateBasePath),
    //         RequestPath = $"/{EPathAccess.Private.ToDescriptionString()}",
    //         OnPrepareResponse = ctx =>
    //         {
    //             if (ctx.Context.User.UsuarioAutenticado()) return;
    //
    //             // respond HTTP 401 Unauthorized.
    //             ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
    //             ctx.Context.Response.ContentLength = 0;
    //             ctx.Context.Response.Body = Stream.Null;
    //             ctx.Context.Response.Headers.Add("Cache-Control", "no-store");
    //         }
    //     });
    // }
}