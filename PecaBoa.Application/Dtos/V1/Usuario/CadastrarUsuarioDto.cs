using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Usuario;

public class CadastrarUsuarioDto
{
    public string Nome { get; set; } = null!;
    public string? NomeSocial { get; set; }
    public string Email { get; set; } = null!;
    public string? Telefone { get; set; }
    public string Cpf { get; set; } = null!;
    public string Senha { get; set; } = null!;
    [Required(ErrorMessage = "A confirmação da senha é necessária")]
    public string ConfirmacaoSenha { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Uf { get; set; } = null!;
    public string Rua { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public int Numero { get; set; }
    public string? Complemento { get; set; }
    public bool Desativado { get; set; }
    public List<GrupoAcessoUsuarioDto> GrupoAcessos { get; set; } = new();
}

public class GrupoAcessoUsuarioDto
{
    public int GrupoAcessoId { get; set; }
}