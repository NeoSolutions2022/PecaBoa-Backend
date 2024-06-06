using PecaBoa.Application.Dtos.V1.Administrador.Status;

namespace PecaBoa.Application.Contracts;

public interface IStatusService
{
    Task<List<StatusDto>> Listar();
}