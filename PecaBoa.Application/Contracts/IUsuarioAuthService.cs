using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Usuario;

namespace PecaBoa.Application.Contracts;

public interface IUsuarioAuthService
{
    Task<UsuarioAutenticadoDto?> Login(LoginDto loginDto);
    Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaUsuarioDto dto);
    Task RecuperarSenha(RecuperarSenhaUsuarioDto dto);
    Task AlterarSenha(AlterarSenhaUsuarioDto dto);
}