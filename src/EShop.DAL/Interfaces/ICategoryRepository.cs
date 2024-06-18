using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface ICategoryRepository
{
    Task<Category> AddCategory(Category сategory);
    Task<Category> UpdateCategory(Category сategory);
    Task<Category> GetCategoryById(int id);
    Task DeleteCategoryById(int id);
    
    Task<IEnumerable<Category>> GetAllCategory();
}
