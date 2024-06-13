using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.GruposDeAcesso;
using PecaBoa.Application.Dtos.V1.Permissoes;

namespace PecaBoa.Application.Contracts;

public interface IPermissaoService
{
    Task<PagedDto<PermissaoDto>> Buscar(BuscarPermissaoDto dto);
    Task<PermissaoDto?> ObterPorId(int id);
    Task<PermissaoDto?> Adicionar(CadastrarPermissaoDto dto);
    Task<PermissaoDto?> Alterar(int id, AlterarPermissaoDto dto);
    Task Deletar(int id);
}