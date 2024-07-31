using Microsoft.AspNetCore.Http;

namespace PecaBoa.Application.Dtos.V1.Usuario;

public class AlterarUsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? NomeSocial { get; set; }
    public string Email { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string? Telefone { get; set; }
    public bool Desativado { get; set; }
    public string Cep { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Uf { get; set; } = null!;
    public string Rua { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public int Numero { get; set; }
    public string? Complemento { get; set; }
    public IFormFile? Foto { get; set; }
    
    public List<ManterGrupoAcessoUsuarioDto> GrupoAcessos { get; set; } = new();
}