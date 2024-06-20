using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem, int>,IOrderItemRepository
{
    public OrderItemRepository(EShopContext context) : base(context)
    {
    }
    
}