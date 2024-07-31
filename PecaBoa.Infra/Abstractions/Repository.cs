﻿using System.Linq.Expressions;
using PecaBoa.Domain.Contracts;
using PecaBoa.Domain.Contracts.Paginacao;
using PecaBoa.Domain.Contracts.Repositories;
using PecaBoa.Domain.Entities;
using PecaBoa.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using PecaBoa.Infra.Context;

namespace PecaBoa.Infra.Abstractions;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot, new()
{
    private bool _isDisposed;
    private readonly DbSet<TEntity> _dbSet;
    protected readonly ApplicationDbContext Context;

    public Repository(ApplicationDbContext context)
    {
        _dbSet = context.Set<TEntity>();
        Context = context;
    }

    public virtual async Task<IResultadoPaginado<TEntity>> Buscar(IBuscaPaginada<TEntity> filtro, CancellationToken cancellationToken = default)
    {
        var queryable = _dbSet.AsQueryable();
        filtro.AplicarFiltro(ref queryable);
        filtro.AplicarOrdenacao(ref queryable);

        return await queryable.BuscarPaginadoAsync(filtro.Pagina, filtro.TamanhoPagina, cancellationToken);
    }

    public async Task<IResultadoPaginado<TEntity>> Buscar(IQueryable<TEntity> queryable, IBuscaPaginada<TEntity> filtro, CancellationToken cancellationToken = default)
    {
        filtro.AplicarFiltro(ref queryable);
        filtro.AplicarOrdenacao(ref queryable);
        
        return await queryable.BuscarPaginadoAsync(filtro.Pagina, filtro.TamanhoPagina, cancellationToken);
    }

    public async Task<List<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> Count(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) 
        => await _dbSet.CountAsync(predicate, cancellationToken);

    public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) 
        => await _dbSet.AnyAsync(predicate, cancellationToken);
    
    public IUnitOfWork UnitOfWork => Context;
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            Context.Dispose();
        }

        _isDisposed = true;
    }
    
    ~Repository()
    {
        Dispose(false);
    }
}