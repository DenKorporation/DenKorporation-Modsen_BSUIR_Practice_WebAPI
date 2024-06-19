using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class CategoryRepository(EShopContext appDbContext) : ICategoryRepository
{
    public async Task<Category> Add(Category entity)
    {
        appDbContext.Categories.Add(entity);
        return entity;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await appDbContext.Categories.FindAsync(id);
    }

    public async Task Update(Category entity)
    {
        appDbContext.Categories.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await appDbContext.Categories.FindAsync(id);
        if (entity != null)
        {
            appDbContext.Categories.Remove(entity);
        }
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await appDbContext.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> Filter(Func<Category, bool> predicate)
    {
        return await Task.FromResult(appDbContext.Categories.Where(predicate).ToList());
    }
}