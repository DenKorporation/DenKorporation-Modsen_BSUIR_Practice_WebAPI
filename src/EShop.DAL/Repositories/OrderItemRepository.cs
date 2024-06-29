using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem, Guid>,IOrderItemRepository
{
    public OrderItemRepository(EShopContext context) : base(context)
    {
    }
    public override async Task<OrderItem?> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.OrderItems
            .AsNoTracking()
            .Include(oi => oi.Product)
            .Include(oi => oi.Order)
            .FirstOrDefaultAsync(oi => oi.Id == id, cancellationToken);
    }
}