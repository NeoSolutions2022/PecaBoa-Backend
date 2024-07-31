using PecaBoa.Application.Adapters.Asaas.Application.Dtos.V1.Customers;

namespace PecaBoa.Application.Adapters.Asaas.Application.Contracts;

public interface ICustomerService
{
    Task<CustomerResponseDto?> GetById(string id);
    Task<List<CustomerResponseDto>?> GetByEmail(string email);
    Task<CustomerResponseDto?> Create(CreateCustomerDto dto);
    Task<bool> Remove(string id);
}