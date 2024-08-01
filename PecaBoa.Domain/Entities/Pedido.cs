using FluentValidation.Results;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Validation;

namespace PecaBoa.Domain.Entities;

public class Pedido : Entity, IAggregateRoot, ISoftDelete
{
    public string? Foto { get; set; }
    public string? Foto2 { get; set; }
    public string? Foto3 { get; set; }
    public string? Foto4 { get; set; }
    public string? Foto5 { get; set; }
    public string NomePeca { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public int MarcaId { get; set; }
    public int ModeloId { get; set; }
    public int CategoriaVeiculoId { get; set; }
    public DateOnly? AnoDeFabricacao { get; set; } = null!;
    public string Cor { get; set; } = null!;
    public bool Desativado { get; set; }
    public int UsuarioId { get; set; }
    public int TipoDePecaId { get; set; }
    public int StatusId { get; set; }
    public DateTime DataFim { get; set; }
    public DateTime DataLimite { get; set; }
    
    public Usuario Usuario { get; set; } = null!;
    public Marca Marca { get; set; } = null!;
    public Modelo Modelo { get; set; } = null!;
    public Status Status { get; set; } = null!;
    public List<Orcamento> Orcamentos { get; set; } = new();

    public override bool Validar(out ValidationResult validationResult)
    {
        validationResult = new PedidoValidator().Validate(this);
        return validationResult.IsValid;
    }
}