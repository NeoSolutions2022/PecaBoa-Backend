using System.ComponentModel;

namespace PecaBoa.Domain.Entities.Enum;

public enum EStatus
{
    [Description("Anúncio Ativo")]
    AnuncioAtivo = 1,
    [Description("Vendido")]
    Vendido = 2,
    [Description("Comprado")]
    Comprado = 3,
    [Description("Cancelado")]
    Cancelado = 4
}