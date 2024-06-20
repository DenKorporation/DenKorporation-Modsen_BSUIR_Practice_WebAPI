using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class ProductRepository :BaseRepository<Product, int>, IProductRepository
{
    public ProductRepository(EShopContext context) : base(context)
    {
    }
}