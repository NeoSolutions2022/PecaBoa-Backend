﻿using System.Linq.Expressions;
using PecaBoa.Core.Utils;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Contracts.Paginacao;

namespace PecaBoa.Application.Dtos.V1.Base;

public class BuscaPaginadaDto<T> : IViewModel, IBuscaPaginada<T> where T : IEntity
{
    private const int TamanhoMaxPagina = 100;
    private const string DirecaoOrdenacaoPadrao = "asc";
    private readonly string[] _opcoesDirecoesOrdenacao = { "asc", "desc" };

    public int Pagina { get; set; } = 1;
    private int _tamanhoPagina = 10;
    public int TamanhoPagina
    {
        get => _tamanhoPagina;
        set => _tamanhoPagina = (value > TamanhoMaxPagina) ? TamanhoMaxPagina : value;
    }

    public string OrdenarPor { get; set; } = "id";
    private string _direcaoOrdenacao = DirecaoOrdenacaoPadrao;
    public string DirecaoOrdenacao
    {
        get => _direcaoOrdenacao;
        set =>
            _direcaoOrdenacao = _opcoesDirecoesOrdenacao.Contains(value.ToLower()) 
                ? value.ToLower() 
                : DirecaoOrdenacaoPadrao;
    }

    public virtual void AplicarFiltro(ref IQueryable<T> query)
    { }

    public virtual void AplicarOrdenacao(ref IQueryable<T> query)
    {
        query = query.OrderBy(o => o.Id);
    }

    public virtual Expression<Func<T, bool>> MontarExpressao()
    {
        return PredicatedUtils.True<T>();
    }
}