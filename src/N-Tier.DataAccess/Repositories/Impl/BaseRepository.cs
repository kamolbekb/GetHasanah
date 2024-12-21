﻿using Microsoft.EntityFrameworkCore;
using N_Tier.Core.Common;
using N_Tier.Core.Exceptions;
using N_Tier.DataAccess.Persistence;
using System.Linq.Expressions;

namespace N_Tier.DataAccess.Repositories.Impl;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    private readonly DbContext _appDbContext;

    public BaseRepository(DbContext dbContext)=>
        _appDbContext = dbContext;

    public async ValueTask<TEntity> InsertAsync(
        TEntity entity)
    {
        var entityEntry = await _appDbContext
            .AddAsync<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public IQueryable<TEntity> SelectAll() =>
        _appDbContext.Set<TEntity>();

    public async ValueTask<TEntity> SelectByIdAsync(int id) =>
        await _appDbContext.Set<TEntity>().FindAsync(id);

    public async Task<List<TEntity>> SelectAllWithIncludesAsync(params string[] includes)
    {
        IQueryable<TEntity> query = _appDbContext.Set<TEntity>();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _appDbContext
            .Update<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entityEntry = _appDbContext
            .Set<TEntity>()
            .Remove(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<int> SaveChangesAsync()=>    
        await _appDbContext
            .SaveChangesAsync();
}
