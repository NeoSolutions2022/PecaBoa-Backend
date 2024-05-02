using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PecaBoa.Application.Configuration.DependencyInjection;

public static class HangfireConfiguration
{
    public static void AddHangfireConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HangfireConnection");

        var postgreStorage = new PostgreSqlStorage(connectionString, new PostgreSqlStorageOptions
        {
            //CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            //UseRecommendedIsolationLevel = true,
            //DisableGlobalLocks = true
        });
        
        services.AddHangfire(config =>
        {
            config
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings();

            config
                .UseStorage(postgreStorage);
        });

        JobStorage.Current = postgreStorage;
        services.AddHangfireServer();
    }
}