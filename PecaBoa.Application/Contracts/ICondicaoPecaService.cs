using PecaBoa.Application.Dtos.V1.Administrador.CondicaoPeca;

namespace PecaBoa.Application.Contracts;

public interface ICondicaoPecaService
{
    Task<List<CondicaoPecaDto>> Listar();
}