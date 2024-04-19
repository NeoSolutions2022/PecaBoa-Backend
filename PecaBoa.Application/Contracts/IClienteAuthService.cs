using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Cliente;

namespace PecaBoa.Application.Contracts;

public interface IClienteAuthService
{
    Task<UsuarioAutenticadoDto?> Login(LoginDto loginDto);
    Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaClienteDto dto);
    Task RecuperarSenha(RecuperarSenhaClienteDto dto);
    Task AlterarSenha(AlterarSenhaClienteDto dto);
}