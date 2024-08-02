using System.Net;
using AutoMapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PecaBoa.Application.Adapters.Asaas.Application.Contracts;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments;
using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Subscriptions;
using PecaBoa.Application.Notification;
using PecaBoa.Application.Notification.CustomerEntitiesError;
using PecaBoa.Application.Services;
using PecaBoa.Core.Extensions;
using PecaBoa.Core.Settings;
using RestSharp;
using SubscriptionDto = PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Payments.SubscriptionDto;

namespace PecaBoa.Application.Adapters.Asaas.Application.Services;

public class SubscriptionService : BaseService, ISubscriptionService
{
    private readonly AsaasSettings _asaasSettings;
    public SubscriptionService(IMapper mapper, INotificator notificator, IOptions<AsaasSettings> asaasSettings) : base(mapper, notificator)
    {
        _asaasSettings = asaasSettings.Value;
    }

    public async Task<SubscriptionResponseDto?> Create(SubscriptionDto dto)
    {
        var options = new RestClientOptions($"{_asaasSettings.BaseUrl}/subscriptions");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("content-type", "application/json");
        request.AddHeader("access_token", $"{_asaasSettings.AccessToken.FromBase64()}");
        var json = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.None,
            DateFormatString = "yyyy-MM-dd"
        });
        request.AddJsonBody(json, false);
        var response = await client.ExecutePostAsync(request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var subscription = JsonConvert.DeserializeObject<SubscriptionResponseDto>(response.Content!);
                return subscription;
            }

            case HttpStatusCode.BadRequest:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }

            case HttpStatusCode.Unauthorized:
            {
                Notificator.Handle($"Assas error: 401 - Unauthorized");
                return null;
            }

            default:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }
        }
    }
    
    public async Task<SubscriptionResponseDto?> Create(SubscriptionDebitDto dto)
    {
        var options = new RestClientOptions($"{_asaasSettings.BaseUrl}/subscriptions");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("content-type", "application/json");
        request.AddHeader("access_token", $"{_asaasSettings.AccessToken.FromBase64()}");
        var json = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            },
            Formatting = Formatting.None,
            DateFormatString = "yyyy-MM-dd"
        });
        request.AddJsonBody(json, false);
        var response = await client.ExecutePostAsync(request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var subscription = JsonConvert.DeserializeObject<SubscriptionResponseDto>(response.Content!);
                return subscription;
            }

            case HttpStatusCode.BadRequest:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }

            case HttpStatusCode.Unauthorized:
            {
                Notificator.Handle($"Assas error: 401 - Unauthorized");
                return null;
            }

            default:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }
        }
    }

    public async Task<SubscriptionResponseListDto?> GetByCustomerId(string customerId)
    {
        var options = new RestClientOptions($"{_asaasSettings.BaseUrl}/subscriptions/?customer={customerId}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("content-type", "application/json");
        request.AddHeader("access_token", $"{_asaasSettings.AccessToken.FromBase64()}");
        var response = await client.ExecuteGetAsync(request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var customers = JsonConvert.DeserializeObject<SubscriptionResponseListDto>(response.Content!);
                return customers;
            }

            case HttpStatusCode.BadRequest:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }

            case HttpStatusCode.Unauthorized:
            {
                Notificator.Handle($"Assas error: 401 - Unauthorized");
                return null;
            }

            default:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }
        }
    }

    public async Task<SubscriptionUnsubscribreResponseDto?> Unsubscribe(string id)
    {
        var options = new RestClientOptions($"{_asaasSettings.BaseUrl}/subscriptions/{id}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("content-type", "application/json");
        request.AddHeader("access_token", $"{_asaasSettings.AccessToken.FromBase64()}");
        var response = await client.DeleteAsync(request);
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
            {
                var subscription = JsonConvert.DeserializeObject<SubscriptionUnsubscribreResponseDto>(response.Content!);
                return subscription!;
            }

            case HttpStatusCode.BadRequest:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }

            case HttpStatusCode.Unauthorized:
            {
                Notificator.Handle($"Assas error: 401 - Unauthorized");
                return null;
            }

            default:
            {
                Notificator.Handle(JsonConvert.DeserializeObject<AsaasError>(response.Content!)!);
                return null;
            }
        }
    }
}