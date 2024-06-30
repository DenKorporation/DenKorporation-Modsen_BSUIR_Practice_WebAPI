using AutoMapper;
using EShop.BLL.DTO.Category;
using EShop.BLL.DTO.Order;
using EShop.BLL.Interfaces;
using EShop.BLL.Validators;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using FluentValidation;

namespace EShop.BLL.Services;

public class CategoryService(IMapper mapper, IUnitOfWork unitOfWork) : ICategoryService
{
    public async Task<ReadCategoryDto?> CreateCategoryAsync(CreateCategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        if (categoryDto == null) throw new ArgumentNullException(nameof(categoryDto));
          
        var category = mapper.Map<Category>(categoryDto);
        var createdCategory = await unitOfWork.Categories.AddAsync(category, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadCategoryDto>(createdCategory);
    }

    public async Task<IEnumerable<ReadCategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await unitOfWork.Categories.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ReadCategoryDto>>(categories);
    }

    public async Task<ReadCategoryDto?> UpdateCategoryAsync(Guid id, CreateCategoryDto categoryDto, CancellationToken cancellationToken = default)
    {
        if (categoryDto == null) throw new ArgumentNullException(nameof(categoryDto));
        
        var category = mapper.Map<Category>(categoryDto);
        var categoryDb = await unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
        if (categoryDb == null)
        {
            return null;
        }

        categoryDb.Name = category.Name;
        
        await unitOfWork.Categories.Update(categoryDb);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadCategoryDto>(categoryDb);
    }

    public async Task<bool> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            return false;
        }

        await unitOfWork.Categories.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ReadCategoryDto?> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
        return category == null ? null : mapper.Map<ReadCategoryDto>(category);
    }
}