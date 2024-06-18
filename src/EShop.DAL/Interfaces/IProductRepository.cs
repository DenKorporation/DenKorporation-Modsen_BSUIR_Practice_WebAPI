using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface IProductRepository
{
    Task<Product> AddProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task<Product> GetProductById(int id);
    Task DeleteProductById(int id);

    Task<IEnumerable<Product>> GetAllProducts();
    Task<IEnumerable<Product>> GetProductsByCategory(Category category);    
}
