using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.DAL.Interfaces;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    protected readonly EShopContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(EShopContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task Delete(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> Filter(Func<TEntity, bool> predicate)
    {
        return await Task.FromResult(_dbSet.Where(predicate).ToList());
    }
}