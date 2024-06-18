using EShop.BLL.DTO.Category;

namespace EShop.BLL.Interfaces;

public interface ICategoryService
{
    Task<ReadCategoryDto?> CreateCategoryAsync(
        CreateCategoryDto categoryDto, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ReadCategoryDto>> GetCategoriesAsync(
        CancellationToken cancellationToken = default);
    
    Task<ReadCategoryDto?> UpdateCategoryAsync(
        Guid id, CreateCategoryDto categoryDto, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteCategoryAsync(
        Guid id, CancellationToken cancellationToken = default);
    
    Task<ReadCategoryDto?> GetCategoryByIdAsync(
        Guid id, CancellationToken cancellationToken = default);
}