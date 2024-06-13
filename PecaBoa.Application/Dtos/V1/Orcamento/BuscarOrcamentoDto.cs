using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Entities.Enum;

namespace PecaBoa.Application.Dtos.V1.Orcamento;

public class BuscarOrcamentoDto : BuscaPaginadaDto<Domain.Entities.Orcamento>
{
    public DateOnly? PrazoDeEntrega { get; set; }
    public EStatus? StatusId { get; set; }
    public ECondicaoPeca? CondicaoPecaId { get; set; }
    public int? PedidoId { get; set; }
    public int? LojistaId { get; set; }
    public bool? Desativado { get; set; }

    public override void AplicarFiltro(ref IQueryable<Domain.Entities.Orcamento> query)
    {
        var expression = MontarExpressao();
        
        base.AplicarFiltro(ref query);

        if (PrazoDeEntrega.HasValue)
        {
            query = query.Where(c => c.PrazoDeEntrega == PrazoDeEntrega);
        }

        if (StatusId is > 0)
        {
            query = query.Where(c => c.StatusId == (int)StatusId);
        }

        if (CondicaoPecaId is > 0)
        {
            query = query.Where(c => c.CondicaoPecaId == (int)CondicaoPecaId);
        }
        
        if (PedidoId.HasValue)
        {
            query = query.Where(c => c.PedidoId == PedidoId);
        }

        if (LojistaId.HasValue)
        {
            query = query.Where(c => c.LojistaId == LojistaId);
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
                "PrazoDeEntrega" => query.OrderBy(c => c.PrazoDeEntrega),
                "Status" => query.OrderBy(c => c.StatusId),
                "CondicaoPeca" => query.OrderBy(c => c.CondicaoPecaId),
                "PedidoId" => query.OrderBy(c => c.PedidoId),
                "LojistaId" => query.OrderBy(c => c.LojistaId),
                "Desativado" => query.OrderBy(c => c.Desativado),
                "id" or _ => query.OrderBy(c => c.Id)
            };
            return;
        }

        query = OrdenarPor.ToLower() switch
        {
            "DataDeEntrega" => query.OrderByDescending(c => c.PrazoDeEntrega),
            "Status" => query.OrderByDescending(c => c.StatusId),
            "CondicaoPeca" => query.OrderByDescending(c => c.CondicaoPecaId),
            "PedidoId" => query.OrderByDescending(c => c.PedidoId),
            "UsuarioId" => query.OrderByDescending(c => c.LojistaId),
            "Desativado" => query.OrderByDescending(c => c.Desativado),
            "id" or _ => query.OrderBy(c => c.Id)
        };
    }
}