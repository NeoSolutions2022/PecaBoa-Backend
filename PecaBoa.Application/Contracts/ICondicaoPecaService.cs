using PecaBoa.Application.Dtos.V1.Usuario.CondicaoPeca;

namespace PecaBoa.Application.Contracts;

public interface ICondicaoPecaService
{
    Task<List<CondicaoPecaDto>> Listar();
}