using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Core.Extensions;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class BuscarPedidoDto : BuscaPaginadaDto<Domain.Entities.Pedido>
{
    public string? NomePeca { get; set; } = null!;
    public string? Descricao { get; set; } = null!; 
    public string? Categoria { get; set; } = null!;
    public string? Marca { get; set; } = null!;
    public string? Modelo { get; set; } = null!;
    public DateOnly? AnoDeFabricacao { get; set; } = null!;
    public string? Cor { get; set; } = null!;
    public override void AplicarFiltro(ref IQueryable<Domain.Entities.Pedido> query)
    {
        var expression = MontarExpressao();

        if (!string.IsNullOrWhiteSpace(NomePeca))
        {
            query = query.Where(c => c.NomePeca.Contains(NomePeca));
        }
        
        if (!string.IsNullOrWhiteSpace(Descricao))
        {
            query = query.Where(c => c.Descricao.Contains(Descricao));
        }

        if (!string.IsNullOrWhiteSpace(Categoria))
        {
            query = query.Where(c => c.Categoria.Contains(Categoria));
        }
        
        if (!string.IsNullOrWhiteSpace(Marca))
        {
            query = query.Where(c => c.Marca.Contains(Marca));
        }
        
        if (!string.IsNullOrWhiteSpace(Modelo))
        {
            query = query.Where(c => c.Modelo.Contains(Modelo));
        }

        if (AnoDeFabricacao.HasValue)
        {
            query = query.Where(c => c.AnoDeFabricacao == AnoDeFabricacao);
        }
        
        if (!string.IsNullOrWhiteSpace(Cor))
        {
            query = query.Where(c => c.Cor.Contains(Cor));
        }

        query = query.Where(expression);
    }

    public override void AplicarOrdenacao(ref IQueryable<Domain.Entities.Pedido> query)
    {
        if (DirecaoOrdenacao.EqualsIgnoreCase("asc"))
        {
            query = OrdenarPor.ToLower() switch
            {
                "titulo" => query.OrderBy(c => c.NomePeca),
                "descricao" => query.OrderBy(c => c.Descricao),
                "categoria" => query.OrderBy(c => c.Categoria),
                "Marca" => query.OrderBy(c => c.Marca),
                "Modelo" => query.OrderBy(c => c.Modelo),
                "AnoDeFabricacao" => query.OrderBy(c => c.AnoDeFabricacao),
                "Cor" => query.OrderBy(c => c.Cor),
                "id" or _ => query.OrderBy(c => c.Id)
            };
            return;
        }
        
        query = OrdenarPor.ToLower() switch
        {
            "titulo" => query.OrderByDescending(c => c.NomePeca),
            "descricao" => query.OrderByDescending(c => c.Descricao),
            "categoria" => query.OrderByDescending(c => c.Categoria),
            "Marca" => query.OrderByDescending(c => c.Marca),
            "Modelo" => query.OrderByDescending(c => c.Modelo),
            "AnoDeFabricacao" => query.OrderByDescending(c => c.AnoDeFabricacao),
            "Cor" => query.OrderByDescending(c => c.Cor),
            "id" or _ => query.OrderByDescending(c => c.Id)
        };
    }
}