using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Lojista;

namespace PecaBoa.Application.Contracts;

public interface ILojistaAuthService
{
    Task<UsuarioAutenticadoDto?> Login(LoginDto loginDto);
    Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaLojistaDto dto);
    Task RecuperarSenha(RecuperarSenhaLojistaDto dto);
    Task AlterarSenha(AlterarSenhaLojistaDto dto);
}