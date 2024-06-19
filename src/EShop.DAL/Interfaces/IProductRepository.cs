using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface IProductRepository: IBaseRepository<Product, int>
{
    Task<IEnumerable<Product>> GetProductsByCategory(Category category);    
}
