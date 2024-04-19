using PecaBoa.Application.Dtos.V1.Auth;
using PecaBoa.Application.Dtos.V1.Fornecedor;

namespace PecaBoa.Application.Contracts;

public interface IFornecedorAuthService
{
    Task<UsuarioAutenticadoDto?> Login(LoginDto loginDto);
    Task<bool> VerificarCodigo(VerificarCodigoResetarSenhaFornecedorDto dto);
    Task RecuperarSenha(RecuperarSenhaFornecedorDto dto);
    Task AlterarSenha(AlterarSenhaFornecedorDto dto);
}