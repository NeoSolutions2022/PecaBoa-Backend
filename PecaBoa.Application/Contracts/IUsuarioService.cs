using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Contracts;

public interface IUsuarioService
{
    Task<PagedDto<UsuarioDto>> Buscar(BuscarUsuarioDto dto);
    Task<UsuarioDto?> Cadastrar(CadastrarUsuarioDto dto);
    Task<UsuarioDto?> Alterar(int id, AlterarUsuarioDto dto);
    Task<UsuarioDto?> ObterPorId(int id);
    Task<UsuarioDto?> ObterPorEmail(string email);
    Task<UsuarioDto?> ObterPorCpf(string cpf);
    public Task AlterarSenha(int id);
    Task Desativar(int id);
    Task Reativar(int id);
    Task Remover(int id);
}