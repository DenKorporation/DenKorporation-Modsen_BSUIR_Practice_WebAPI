using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Interfaces;

public interface IBaseRepository<TEntity, TKey>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task Update(TEntity entity);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> FilterAsync(Func<TEntity, bool> predicate, CancellationToken cancellationToken = default);
    Task<TEntity?> GetDetailsByIdAsync(TKey id, CancellationToken cancellationToken = default); 
}
