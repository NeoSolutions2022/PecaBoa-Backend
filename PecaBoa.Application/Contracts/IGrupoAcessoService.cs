using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Contracts;

public interface IGrupoAcessoService
{
    Task<GrupoAcessoDto?> ObterPorId(int id);
    Task<GrupoAcessoDto?> Cadastrar(CadastrarGrupoAcessoDto dto);
    Task<GrupoAcessoDto?> Alterar(int id, AlterarGrupoAcessoDto dto); 
    Task Reativar(int id);
    Task<PagedDto<GrupoAcessoDto>> Buscar(BuscarGrupoAcessoDto dto);
    Task Desativar(int id);
}