using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Core.Extensions;
using PecaBoa.Domain.Entities.Enum;

namespace PecaBoa.Application.Dtos.V1.Pedido;

public class BuscarPedidoDto : BuscaPaginadaDto<Domain.Entities.Pedido>
{
    public string? NomePeca { get; set; }
    public string? Descricao { get; set; } 
    public EStatus? StatusId { get; set; }
    public ETipoPeca? TipoDePecaId { get; set; }
    public ECategoriaVeiculo? CategoriaVeiculoId { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public DateOnly? AnoDeFabricacao { get; set; }
    public string? Cor { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }
    
    public override void AplicarFiltro(ref IQueryable<Domain.Entities.Pedido> query)
    {
        var expression = MontarExpressao();

        if (!string.IsNullOrWhiteSpace(NomePeca))
        {
            query = query.Where(c => c.NomePeca.ToLower().Contains(NomePeca.ToLower()));
        }
        
        if (!string.IsNullOrWhiteSpace(Descricao))
        {
            query = query.Where(c => c.Descricao.Contains(Descricao));
        }

        if (StatusId is > 0)
        {
            query = query.Where(c => c.StatusId == (int)StatusId);
        }

        if (TipoDePecaId is > 0)
        {
            query = query.Where(c => c.TipoDePecaId == (int)TipoDePecaId);
        }

        if (CategoriaVeiculoId is > 0)
        {
            query = query.Where(c => c.CategoriaVeiculoId == (int)CategoriaVeiculoId);
        }
        if (!string.IsNullOrWhiteSpace(Marca))
        {
            query = query.Where(c => c.Marca.Nome.Contains(Marca));
        }
        
        if (!string.IsNullOrWhiteSpace(Modelo))
        {
            query = query.Where(c => c.Modelo.Nome.Contains(Modelo));
        }

        if (AnoDeFabricacao.HasValue)
        {
            query = query.Where(c => c.AnoDeFabricacao == AnoDeFabricacao);
        }
        
        if (!string.IsNullOrWhiteSpace(Cor))
        {
            query = query.Where(c => c.Cor.Contains(Cor));
        }

        if (!string.IsNullOrEmpty(Cidade))
        {
            query = query.Where(c => c.Usuario.Cidade.ToLower().Contains(Cidade.ToLower()));
        }

        if (!string.IsNullOrEmpty(Uf))
        {
            query = query.Where(c => c.Usuario.Uf.ToLower().Contains(Uf.ToLower()));
        }

        query = query.Where(expression);
    }

    public override void AplicarOrdenacao(ref IQueryable<Domain.Entities.Pedido> query)
    {
        if (DirecaoOrdenacao.EqualsIgnoreCase("asc"))
        {
            query = OrdenarPor.ToLower() switch
            {
                "NomePeca" => query.OrderBy(c => c.NomePeca),
                "Descricao" => query.OrderBy(c => c.Descricao),
                "Status" => query.OrderBy(c => c.StatusId),
                "TipoDePeca" => query.OrderBy(c => c.TipoDePecaId),
                "Marca" => query.OrderBy(c => c.Marca.Nome),
                "Modelo" => query.OrderBy(c => c.Modelo.Nome),
                "AnoDeFabricacao" => query.OrderBy(c => c.AnoDeFabricacao),
                "Cor" => query.OrderBy(c => c.Cor),
                "id" or _ => query.OrderBy(c => c.Id)
            };
            return;
        }
        
        query = OrdenarPor.ToLower() switch
        {
            "NomePeca" => query.OrderByDescending(c => c.NomePeca),
            "Descricao" => query.OrderByDescending(c => c.Descricao),
            "Status" => query.OrderByDescending(c => c.StatusId),
            "TipoDePeca" => query.OrderByDescending(c => c.TipoDePecaId),
            "Marca" => query.OrderByDescending(c => c.Marca.Nome),
            "Modelo" => query.OrderByDescending(c => c.Modelo.Nome),
            "AnoDeFabricacao" => query.OrderByDescending(c => c.AnoDeFabricacao),
            "Cor" => query.OrderByDescending(c => c.Cor),
            "id" or _ => query.OrderByDescending(c => c.Id)
        };
    }
}