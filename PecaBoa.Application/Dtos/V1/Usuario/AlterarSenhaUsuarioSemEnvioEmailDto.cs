namespace PecaBoa.Application.Dtos.V1.Usuario;

public class AlterarSenhaUsuarioSemEnvioEmailDto
{
    public string Senha { get; set; } = null!;
    public string ConfirmarSenha { get; set; } = null!;
}