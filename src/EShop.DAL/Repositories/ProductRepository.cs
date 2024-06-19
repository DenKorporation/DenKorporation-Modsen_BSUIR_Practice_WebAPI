using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class ProductRepository(EShopContext appDbContext) : IProductRepository
{
    public async Task<Product> Add(Product entity)
    {
        appDbContext.Products.Add(entity);
        return entity;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await appDbContext.Products.FindAsync(id);
    }

    public async Task Update(Product entity)
    {
        appDbContext.Products.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await appDbContext.Products.FindAsync(id);
        if (entity != null)
        {
            appDbContext.Products.Remove(entity);
        }
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await appDbContext.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> Filter(Func<Product, bool> predicate)
    {
        return await Task.FromResult(appDbContext.Products.Where(predicate).ToList());
    }
}