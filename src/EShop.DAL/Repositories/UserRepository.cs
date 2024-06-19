using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class UserRepository(EShopContext appDbContext) : IUserRepository
{
    public async Task<User> Add(User entity)
    {
        appDbContext.Users.Add(entity);
        return entity;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await appDbContext.Users.FindAsync(id);
    }

    public async Task Update(User entity)
    {
        appDbContext.Users.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await appDbContext.Users.FindAsync(id);
        if (entity != null)
        {
            appDbContext.Users.Remove(entity);
        }
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await appDbContext.Users.ToListAsync();
    }

    public async Task<IEnumerable<User>> Filter(Func<User, bool> predicate)
    {
        return await Task.FromResult(appDbContext.Users.Where(predicate).ToList());
    }
}