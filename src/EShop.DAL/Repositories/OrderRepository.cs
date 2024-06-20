using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class OrderRepository :BaseRepository<Order, int>, IOrderRepository
{
    public OrderRepository(EShopContext context) : base(context)
    {
    }
}