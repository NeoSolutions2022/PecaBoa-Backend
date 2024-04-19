using PecaBoa.Application.Dtos.V1.Administrador;
using PecaBoa.Application.Dtos.V1.Auth;

namespace PecaBoa.Application.Contracts;

public interface IAuthService
{
    Task<AdministradorAutenticadoDto?> LoginAdministrador(LoginDto loginDto);
    Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaAdministradorDto administradorDto);
    Task RecuperarSenha(RecuperarSenhaAdministradorDto dto);
    Task AlterarSenha(AlterarSenhaAdministradorDto dto);
}