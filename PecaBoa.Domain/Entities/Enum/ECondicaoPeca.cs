using System.ComponentModel;

namespace PecaBoa.Domain.Entities.Enum;

public enum ECondicaoPeca
{
    [Description("Peça Nova")]
    Nova = 1,
    [Description("Peça Usada")]
    Usada = 2,
    [Description("Peça Recondicionada")]
    Recondicionada = 3,
    [Description("Peça Danificada")]
    Danificada = 4,
}