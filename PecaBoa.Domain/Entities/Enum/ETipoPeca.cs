using System.ComponentModel;

namespace PecaBoa.Domain.Entities.Enum;

public enum ETipoPeca
{
    [Description("Peça do Motor")]
    Motor = 1,
    [Description("Peça da Trasmissão")]
    Transmissao = 2,
    [Description("Peça da Suspensão")]
    Suspensao = 3,
    [Description("Peça do sistema de Freios")]
    Freios = 4,
    [Description("Peça da parte Elétrica")]
    Eletrica = 5,
    [Description("Peça da Carroceria")]
    Carroceria = 6,
    [Description("Peça do interior")]
    Interior = 7,
    [Description("Peça do sistema de exaustão")]
    Exaustao = 8,
    [Description("Peça do sistema de Direção")]
    Direcao = 9,
    [Description("Pneus")]
    Pneus = 10,
    [Description("Vidros")]
    Vidros = 11
}