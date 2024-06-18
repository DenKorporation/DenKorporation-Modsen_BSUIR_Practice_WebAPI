using EShop.BLL.DTO.Product;

namespace EShop.BLL.Interfaces;

public interface IProductService
{
    Task<ReadProductDto?> CreateProductAsync(
        CreateProductDto productDto, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ReadProductDto>> GetProductsAsync(
        CancellationToken cancellationToken = default);
    
    Task<ReadProductDto?> UpdateProductAsync(
        Guid id, CreateProductDto productDto, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteProductAsync(
        Guid id, CancellationToken cancellationToken = default);
    
    Task<ProductDetailsDto?> GetProductByIdAsync(
        Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadProductDto>> GetProductByCategoryAsync(
        Guid categoryId, CancellationToken cancellationToken = default);
}