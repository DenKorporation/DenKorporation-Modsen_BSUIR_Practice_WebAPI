using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class ProductRepository :BaseRepository<Product, Guid>, IProductRepository
{
    public ProductRepository(EShopContext context) : base(context)
    {
    }   
    public override async Task<Product?> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.OrderItems)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}