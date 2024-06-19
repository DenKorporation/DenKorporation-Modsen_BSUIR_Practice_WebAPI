using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Interfaces;

public interface IBaseRepository<TEntity, TKey>
{
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> GetByIdAsync(TKey id);
    Task Update(TEntity entity);
    Task Delete(TKey id);

    Task<IEnumerable<TEntity>> GetAll();
}
