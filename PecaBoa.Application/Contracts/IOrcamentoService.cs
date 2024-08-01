using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Orcamento;

namespace PecaBoa.Application.Contracts;

public interface IOrcamentoService
{
    Task<OrcamentoDto?> Adicionar(CadastrarOrcamentoDto dto);
    Task<OrcamentoDto?> Alterar(int id, AlterarOrcamentoDto dto);
    Task<OrcamentoDto?> ObterPorId(int id);
    Task Desativar(int id);
    Task Reativar(int id);
    Task Remover(int id);
    Task<PagedDto<OrcamentoDto>> Buscar(BuscarOrcamentoDto dto);
    Task<List<OrcamentoDto>> BuscarOrcamentosLojista();
    Task AlterarFoto(AlterarFotoOrcamentoDto dto);
    Task RemoverFoto(RemoverFotosOrcamentoDto dto);
}