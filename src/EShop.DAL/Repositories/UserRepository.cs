using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class UserRepository :BaseRepository<User, Guid>, IUserRepository
{
    public UserRepository(EShopContext context) : base(context)
    {
    }

    public override async Task<User?> GetDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(u => u.Orders)
            .FirstOrDefaultAsync(oi => oi.Id == id, cancellationToken);
    }
}