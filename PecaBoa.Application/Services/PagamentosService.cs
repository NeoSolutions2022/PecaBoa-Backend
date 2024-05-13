using AutoMapper;
using PecaBoa.Application.Contracts;
using PecaBoa.Application.Notification;
using PecaBoa.Domain.Contracts.Repositories;
using MercadoPago.Client;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Services;

public class PagamentosService : BaseService, IPagamentosService

{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUsuarioRepository _usuarioRepository;
    public PagamentosService(IMapper mapper, INotificator notificator, IHttpContextAccessor httpContextAccessor, IUsuarioRepository usuarioRepository) : base(mapper, notificator)
    {
        _httpContextAccessor = httpContextAccessor;
        _usuarioRepository = usuarioRepository;
        MercadoPagoConfig.AccessToken = "YOUR_ACCESS_TOKEN";
    }

    public async Task PagarComCartao(string token)
    {
        var claimEmail =  _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "Email");
        if (claimEmail.Value == null)
        {
            return;
        }

        var usuario = await _usuarioRepository.ObterPorEmail(claimEmail.Value);
        if (usuario == null)
        {
            return;
        }
        
        var request = new PaymentCreateRequest
        {
            TransactionAmount = (decimal)1.0,
            Token = token,
            Description = "Assinatura Mundo Web",
            Installments = 1,
            PaymentMethodId = "visa",
            Payer = new PaymentPayerRequest
            {
                Email = claimEmail.Value,
            }
        };
        
        var requestOptions = new RequestOptions();
        requestOptions.AccessToken = "YOUR_ACCESS_TOKEN";

        var client = new PaymentClient();
        Payment payment = await client.CreateAsync(request, requestOptions);

        if (payment.Status == "approved")
        {
            //Usuario.Inadiplente = false;
            //Usuario.DataPagamento = DateTime.Now.AddMonths(1);
            return;
        }
        
        Notificator.Handle(payment.Status);
    }
    
}