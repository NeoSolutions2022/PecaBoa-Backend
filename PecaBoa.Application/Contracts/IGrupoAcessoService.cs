using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Domain.Entities;

namespace PecaBoa.Application.Contracts;

public interface IGrupoAcessoService
{
    Task<GrupoAcessoDto?> ObterPorId(int id);
    Task<GrupoAcessoDto?> Cadastrar(CadastrarGrupoAcessoDto dto);
    Task<GrupoAcessoDto?> Alterar(int id, AlterarGrupoAcessoDto dto);
    Task<List<GrupoDeAcessoFiltroDto>> Filtrar(List<FiltragemGrupoDeAcessoDto> dto, List<GrupoAcesso>? agremiacoes = null, int tamanho = 0, int aux = 0);
    Task Reativar(int id);
    Task<PagedDto<GrupoAcessoDto>> Buscar(BuscarGrupoAcessoDto dto);
    Task Desativar(int id);
    Task<List<GrupoDeAcessoFiltroDto>> Pesquisar(string valor);
    Task LimparFiltro();
}