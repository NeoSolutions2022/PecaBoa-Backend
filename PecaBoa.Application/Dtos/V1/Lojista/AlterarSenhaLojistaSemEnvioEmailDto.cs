namespace PecaBoa.Application.Dtos.V1.Lojista;

public class AlterarSenhaLojistaSemEnvioEmailDto
{
    public string Senha { get; set; } = null!;
    public string ConfirmarSenha { get; set; } = null!;
}