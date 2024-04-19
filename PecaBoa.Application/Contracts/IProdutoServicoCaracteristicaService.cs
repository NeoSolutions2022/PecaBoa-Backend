using PecaBoa.Application.Dtos.V1.ProdutoServico.ProdutoServicoCaracteristica;

namespace PecaBoa.Application.Contracts;

public interface IProdutoServicoCaracteristicaService
{
    Task<List<ProdutoServicoCaracteristicaDto>?> Adicionar(List<AdicionarProdutoServicoCaracteristicaDto> dto);
    Task<ProdutoServicoCaracteristicaDto?> Alterar(int id, AlterarProdutoServicoCaracteristicaDto dto);
    Task<ProdutoServicoCaracteristicaDto?> ObterPorId(int id);
    Task<List<ProdutoServicoCaracteristicaDto>?> ObterPorTodos(int produtoId);
    Task Remover(int id);
}