using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;

namespace PecaBoa.Application.Adapters.Asaas.Application.Contracts;

public interface IPaymentService
{
    Task VerifyPayment(SubscriptionHookDto dto);
}