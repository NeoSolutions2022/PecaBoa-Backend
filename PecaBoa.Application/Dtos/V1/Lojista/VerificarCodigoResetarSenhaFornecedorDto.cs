namespace PecaBoa.Application.Dtos.V1.Lojista;

public class VerificarCodigoResetarSenhaLojistaDto
{
    public string Email { get; set; } = null!;
    public Guid CodigoResetarSenha { get; set; }
}