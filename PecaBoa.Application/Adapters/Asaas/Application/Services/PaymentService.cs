using AutoMapper;
using PecaBoa.Application.Adapters.Asaas.Application.Contracts;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;
using PecaBoa.Application.Notification;
using PecaBoa.Application.Services;
using PecaBoa.Domain.Contracts.Repositories;

namespace PecaBoa.Application.Adapters.Asaas.Application.Services;

public class PaymentService : BaseService, IPaymentService
{
    private readonly ICustomerService _customerService;
    private readonly ILojistaRepository _lojistaRepository;
    private readonly ISubscriptionService _subscriptionService;

    public PaymentService(IMapper mapper, INotificator notificator, ICustomerService customerService, ISubscriptionService subscriptionService, ILojistaRepository lojistaRepository) : base(mapper, notificator)
    {
        _customerService = customerService;
        _subscriptionService = subscriptionService;
        _lojistaRepository = lojistaRepository;
    }

    public async Task VerifyPayment(SubscriptionHookDto dto)
    {
        switch (dto.Event)
        {
            case "PAYMENT_CREATED":
            {
                var customer = await _customerService.GetById(dto.Payment.Customer);
                if (customer is null)
                {
                    Notificator.Handle("Um erro ocorreu ao tentar buscar o cliente");
                    return;
                }
                
                var user = await _lojistaRepository.ObterPorEmail(customer.Email);
                if (user is null)
                {
                    Notificator.HandleNotFoundResource();
                    return;
                }
                
                var subscriptions = await _subscriptionService.GetByCustomerId(customer.Id);
                if (!(subscriptions!.Data!.OrderBy(s => s.NextDueDate).First().NextDueDate >= DateTime.Now))
                {
                    return;
                }
                
                return;
            }
                
            case "PAYMENT_CREDIT_CARD_CAPTURE_REFUSED":
            {
                var customer = await _customerService.GetById(dto.Payment.Customer);
                if (customer is null)
                {
                    Notificator.Handle("Um erro ocorreu ao tentar buscar o cliente");
                    return;
                }
                
                var user = await _lojistaRepository.ObterPorEmail(customer.Email);
                if (user is null)
                {
                    Notificator.HandleNotFoundResource();
                    return;
                }
                
                user.Desativado = true;
                _lojistaRepository.Alterar(user);
                if (await _lojistaRepository.UnitOfWork.Commit())
                {
                    return;
                }
                    
                Notificator.Handle("Um erro ocorreu ao tentar desabilitar o usuario");
                return;
            }

            case "PAYMENT_CONFIRMED":
            {
                var customer = await _customerService.GetById(dto.Payment.Customer);
                if (customer is null)
                {
                    Notificator.Handle("Não foi possível obter o customer.");
                    return;
                }
                
                var user = await _lojistaRepository.ObterPorEmail(customer.Email);
                if (user is null)
                {
                    Notificator.HandleNotFoundResource();
                    return;
                }
                
                var subscriptions = await _subscriptionService.GetByCustomerId(customer.Id);
                if (!(subscriptions!.Data!.OrderBy(s => s.NextDueDate).First().NextDueDate >= DateTime.Now))
                {
                    return;
                }
                
                return;
            }
        }
    }
}