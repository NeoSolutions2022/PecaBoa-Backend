using PecaBoa.Application.Dtos.V1.Base;
using PecaBoa.Core.Extensions;

namespace PecaBoa.Application.Dtos.V1.Lojista;

public class BuscarLojistaDto : BuscaPaginadaDto<Domain.Entities.Lojista>
{
    public string? Nome { get; set; }
    public string? NomeFantasia { get; set; }
    public bool? Desativado { get; set; }
    public string? Cep { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }
    public string? Bairro { get; set; }
    public string? Categoria { get; set; }
    public bool? AnuncioPago { get; set; }

    public override void AplicarFiltro(ref IQueryable<Domain.Entities.Lojista> query)
    {
        var expression = MontarExpressao();

        if (!string.IsNullOrWhiteSpace(Nome))
        {
            query = query.Where(c => c.Nome.Contains(Nome));
        }
        
        if (!string.IsNullOrWhiteSpace(NomeFantasia))
        {
            query = query.Where(c => c.NomeFantasia.Contains(NomeFantasia));
        }
        
        if (!string.IsNullOrWhiteSpace(Cep))
        {
            query = query.Where(c => c.Cep.Contains(Cep));
        }
        
        if (!string.IsNullOrWhiteSpace(Uf))
        {
            query = query.Where(c => c.Uf.Contains(Uf));
        }
        
        if (!string.IsNullOrWhiteSpace(Cidade))
        {
            query = query.Where(c => c.Cidade.Contains(Cidade));
        }

        if (Desativado.HasValue)
        {
            query = query.Where(c => c.Desativado == Desativado.Value);
        }

        if (!string.IsNullOrWhiteSpace(Bairro))
        {
            query = query.Where(c => c.Bairro.Contains(Bairro));
        }


        if (AnuncioPago.HasValue)
        {
            query = query.Where(c => c.AnuncioPago == AnuncioPago);
        }

        query = query.Where(expression);
    }

    public override void AplicarOrdenacao(ref IQueryable<Domain.Entities.Lojista> query)
    {
        if (DirecaoOrdenacao.EqualsIgnoreCase("asc"))
        {
            query = OrdenarPor.ToLower() switch
            {
                "nome" => query.OrderBy(c => c.Nome),
                "desativado" => query.OrderBy(c => c.Desativado),
                "cep" => query.OrderBy(c => c.Cep),
                "nome fantasia" => query.OrderBy(c => c.NomeFantasia),
                "bairro" => query.OrderBy(c => c.Bairro),
                "cidade" => query.OrderBy(c => c.Cidade),
                "uf" => query.OrderBy(c => c.Uf),
                "id" or _ => query.OrderBy(c => c.Id)
            };
            return;
        }
        
        query = OrdenarPor.ToLower() switch
        {
            "nome" => query.OrderByDescending(c => c.Nome),
            "cep" => query.OrderByDescending(c => c.Cep),
            "cidade" => query.OrderByDescending(c => c.Cidade),
            "nome fantasia" => query.OrderByDescending(c => c.NomeFantasia),
            "bairro" => query.OrderBy(c => c.Bairro),
            "uf" => query.OrderByDescending(c => c.Uf),
            "desativado" => query.OrderByDescending(c => c.Desativado),
            "id" or _ => query.OrderByDescending(c => c.Id)
        };
    }
}