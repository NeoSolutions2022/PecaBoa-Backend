using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class Lojista : Entity, IAggregateRoot, ISoftDelete
{
    public string Cep { get; set; } = null!;
    public string Cidade { get; set; } = null!;
    public string? Cnpj { get; set; }
    public Guid? CodigoResetarSenha { get; set; }
    public DateTime? CodigoResetarSenhaExpiraEm { get; set; }
    public string? Complemento { get; set; }
    public string Cpf { get; set; } = null!;
    public bool Desativado { get; set; }
    public string Email { get; set; } = null!;
    public string? Descricao { get; set; }
    public string Rua { get; set; } = null!;
    public string Bairro { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string? NomeFantasia { get; set; }
    public int Numero { get; set; }
    public string Senha { get; set; } = null!;
    public string? Telefone { get; set; }
    public string Uf { get; set; } = null!;
    public int? RepresentanteId { get; set; }
    
    //public bool AnuncioPago { get; set; }
    //public DateTime? DataPagamentoAnuncio { get; set; }
    //public DateTime? DataExpiracaoAnuncio { get; set; }
    public virtual List<Orcamento> Orcamentos { get; set; } = new();
    public virtual Usuario Usuario { get; set; }

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new LojistaValidator().Validate(this);
        return validationResult.IsValid;
    }

}