using PecaBoa.Core.Extensions;
using Microsoft.AspNetCore.Http;
using PecaBoa.Core.Enums;

namespace PecaBoa.Core.Authorization;

public interface IAuthenticatedUser
{
    public int Id { get; }
    public ETipoUsuario? Administrador { get; }
    public ETipoUsuario? Fornecedor { get; }
    public ETipoUsuario? Usuario { get; }
    public bool UsuarioLogado { get; }
    public bool UsuarioAdministrador { get; }
    public bool UsuarioFornecedor { get; }
    public bool UsuarioUsuario { get; }
}

public class AuthenticatedUser : IAuthenticatedUser
{
    public int Id { get; } = -1;
    public ETipoUsuario? Administrador { get; }
    public ETipoUsuario? Fornecedor { get; }
    public ETipoUsuario? Usuario { get; }
    public ETipoUsuario? TipoUsuario { get; }
    public bool UsuarioLogado => Id > 0;
    public bool UsuarioUsuario => TipoUsuario is ETipoUsuario.Usuario;
    public bool UsuarioFornecedor => TipoUsuario is ETipoUsuario.Fornecedor;
    public bool UsuarioAdministrador => TipoUsuario is ETipoUsuario.Administrador;

    public AuthenticatedUser()
    {
    }

    public AuthenticatedUser(IHttpContextAccessor httpContextAccessor)
    {
        Id = httpContextAccessor.ObterUsuarioId()!.Value;
        TipoUsuario = httpContextAccessor.ObterTipoUsuario()!.Value;
        Administrador = httpContextAccessor.ObterTipoAdministrador()!.Value;
        Fornecedor = httpContextAccessor.ObterTipoFornecedor()!.Value;
        Usuario = httpContextAccessor.ObterTipoUsuario()!.Value;
    }
}