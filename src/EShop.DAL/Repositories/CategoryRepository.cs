using EShop.DAL.Context;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL.Repositories;

public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
{
    public CategoryRepository(EShopContext context) : base(context)
    {
    }
}