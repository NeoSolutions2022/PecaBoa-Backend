using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Subscriptions;
using SubscriptionDto = PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments.SubscriptionDto;

namespace PecaBoa.Application.Adapters.Asaas.Application.Contracts;

public interface ISubscriptionService
{
    Task<SubscriptionResponseDto?> Create(SubscriptionDto dto);
    Task<SubscriptionResponseDto?> Create(SubscriptionDebitDto dto);
    Task<SubscriptionResponseListDto?> GetByCustomerId(string customerId);
    Task<SubscriptionUnsubscribreResponseDto?> Unsubscribe(string id);
}