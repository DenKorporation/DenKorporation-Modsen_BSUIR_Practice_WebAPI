using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class OrderRepository(EShopContext appDbContext) : IOrderRepository
{
    public async Task<Order> Add(Order entity)
    {
        appDbContext.Orders.Add(entity);
        return entity;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await appDbContext.Orders.FindAsync(id);
    }

    public async Task Update(Order entity)
    {
        appDbContext.Orders.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await appDbContext.Orders.FindAsync(id);
        if (entity != null)
        {
            appDbContext.Orders.Remove(entity);
        }
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await appDbContext.Orders.ToListAsync();
    }

    public async Task<IEnumerable<Order>> Filter(Func<Order, bool> predicate)
    {
        return await Task.FromResult(appDbContext.Orders.Where(predicate).ToList());
    }
}