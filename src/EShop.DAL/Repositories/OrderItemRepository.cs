using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class OrderItemRepository(EShopContext appDbContext) : IOrderItemRepository
{
    public async Task<OrderItem> Add(OrderItem entity)
    {
        appDbContext.OrderItems.Add(entity);
        return entity;
    }

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        return await appDbContext.OrderItems.FindAsync(id);
    }

    public async Task Update(OrderItem entity)
    {
        appDbContext.OrderItems.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await appDbContext.OrderItems.FindAsync(id);
        if (entity != null)
        {
            appDbContext.OrderItems.Remove(entity);
        }
    }

    public async Task<IEnumerable<OrderItem>> GetAll()
    {
        return await appDbContext.OrderItems.ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> Filter(Func<OrderItem, bool> predicate)
    {
        return await Task.FromResult(appDbContext.OrderItems.Where(predicate).ToList());
    }
}