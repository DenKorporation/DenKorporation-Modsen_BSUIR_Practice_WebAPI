using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class UserRepository :BaseRepository<User, int>, IUserRepository
{
    public UserRepository(EShopContext context) : base(context)
    {
    }
}