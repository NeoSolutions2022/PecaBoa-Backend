using Microsoft.Extensions.DependencyInjection;
using PecaBoa.Application.Adapters.Asaas.Application.Contracts;
using PecaBoa.Application.Adapters.Asaas.Application.Services;

namespace PecaBoa.Application.Adapters.Asaas;

public static class DependencyInjection
{
    public static void ConfigureAssas(this IServiceCollection services)
    {
        services
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<ISubscriptionService, SubscriptionService>()
            .AddScoped<IPaymentService, PaymentService>();
    }
}