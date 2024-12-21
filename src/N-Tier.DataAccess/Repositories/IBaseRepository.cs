using N_Tier.Core.Common;
using System.Collections;
using System.Linq.Expressions;

namespace N_Tier.DataAccess.Repositories;

public interface IBaseRepository<TEntity, TKey>
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    IQueryable<TEntity> SelectAll();
    ValueTask<TEntity> SelectByIdAsync(TKey id);

    public Task<List<TEntity>> SelectAllWithIncludesAsync(params string[] includes);
    
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(TEntity entity);
    ValueTask<int> SaveChangesAsync();
}
