namespace PecaBoa.Application.Dtos.V1.Usuario;

public class VerificarCodigoResetarSenhaUsuarioDto
{
    public string Email { get; set; } = null!;
    public Guid CodigoResetarSenha { get; set; }
}