using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Core.Extensions;

namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class BuscarOrcamentoDto : BuscaPaginadaDto<Domain.Entities.Orcamento>
{
    public DateOnly? DataDeEntrega { get; set; }
    public int? PedidoId { get; set; }
    public int? UsuarioId { get; set; }
    public bool? Desativado { get; set; }

    public override void AplicarFiltro(ref IQueryable<Domain.Entities.Orcamento> query)
    {
        var expression = MontarExpressao();
        
        base.AplicarFiltro(ref query);

        if (DataDeEntrega.HasValue)
        {
            query = query.Where(c => c.DataDeEntrega == DataDeEntrega);
        }

        if (PedidoId.HasValue)
        {
            query = query.Where(c => c.PedidoId == PedidoId);
        }

        if (UsuarioId.HasValue)
        {
            query = query.Where(c => c.UsuarioId == UsuarioId);
        }
        
        if (Desativado.HasValue)
        {
            query = query.Where(c => c.Desativado == Desativado.Value);
        }

        query = query.Where(expression);
    }

    public override void AplicarOrdenacao(ref IQueryable<Domain.Entities.Orcamento> query)
    {
        if (DirecaoOrdenacao.EqualsIgnoreCase("asc"))
        {
            query = OrdenarPor.ToLower() switch
            {
                "DataDeEntrega" => query.OrderBy(c => c.DataDeEntrega),
                "PedidoId" => query.OrderBy(c => c.PedidoId),
                "UsuarioId" => query.OrderBy(c => c.UsuarioId),
                "Desativado" => query.OrderBy(c => c.Desativado),
                "id" or _ => query.OrderBy(c => c.Id)
            };
            return;
        }

        query = OrdenarPor.ToLower() switch
        {
            "DataDeEntrega" => query.OrderByDescending(c => c.DataDeEntrega),
            "PedidoId" => query.OrderByDescending(c => c.PedidoId),
            "UsuarioId" => query.OrderByDescending(c => c.UsuarioId),
            "Desativado" => query.OrderByDescending(c => c.Desativado),
            "id" or _ => query.OrderBy(c => c.Id)
        };
    }
}