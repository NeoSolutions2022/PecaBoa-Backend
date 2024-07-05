using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class Usuario : Entity, ISoftDelete, IAggregateRoot
{
    public string Nome { get; set; } = null!;
    public string? NomeSocial { get; set; }
    public string Email { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string? Telefone { get; set; }
    public string Senha { get; set; } = null!;
    public string Cep { get; set; } = null!;
    public string Uf { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public string Rua { get; set; } = null!;
    public int Numero { get; set; }
    public string? Complemento { get; set; }
    public int? RepresentanteId { get; set; }
    public bool Desativado { get; set; }
    public Guid? CodigoResetarSenha { get; set; }
    public DateTime? CodigoResetarSenhaExpiraEm { get; set; }
    public virtual List<Pedido> Pedidos { get; set; } = new();
    public List<Usuario> Usuarios { get; set; } = new();
    public List<Lojista> Lojistas { get; set; } = new(); 

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new UsuarioValidator().Validate(this);
        return validationResult.IsValid;
    }
}