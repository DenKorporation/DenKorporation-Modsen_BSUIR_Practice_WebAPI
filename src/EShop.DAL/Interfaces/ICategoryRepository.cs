using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category, int>
{   
    Task<IEnumerable<Category>> GetAllCategory();
}
