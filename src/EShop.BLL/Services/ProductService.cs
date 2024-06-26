using AutoMapper;
using EShop.BLL.DTO.Product;
using EShop.BLL.Interfaces;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using FluentValidation;

namespace EShop.BLL.Services;

public class ProductService(IMapper mapper, IUnitOfWork unitOfWork,AbstractValidator<Product> validator) : IProductService
{
    public async Task<ReadProductDto?> CreateProductAsync(CreateProductDto productDto, CancellationToken cancellationToken = default)
    {
        if (productDto == null) throw new ArgumentNullException(nameof(productDto));

        var product = mapper.Map<Product>(productDto);

        var validationResult = await validator.ValidateAsync(product);

        if (!validationResult.IsValid)
        { throw new Exception("Product data has not been validated");
           
        }

        var createdProduct = await unitOfWork.Products.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<ReadProductDto>(createdProduct);
    }

    public async Task<IEnumerable<ReadProductDto>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var categories = await unitOfWork.Products.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ReadProductDto>>(categories);
    }

    public async Task<ReadProductDto?> UpdateProductAsync(Guid id, CreateProductDto productDto, CancellationToken cancellationToken = default)
    {
        if (productDto == null) throw new ArgumentNullException(nameof(productDto));
        var product = mapper.Map<Product>(productDto);

        var validationResult = await validator.ValidateAsync(product);

        if (!validationResult.IsValid)
        {
            throw new Exception("Product data has not been validated");
        }
        
        var productDb = await unitOfWork.Products.GetByIdAsync(id, cancellationToken);
        if (productDb == null)
        {
            return null;
        }

        productDb.Name = product.Name;
        productDb.CategoryId = product.CategoryId;
        productDb.Description = product.Description;
        productDb.Price = product.Price;
        productDb.AvailableStock = product.AvailableStock;
        
        await unitOfWork.Products.Update(productDb);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadProductDto>(productDb);
    }

    public async Task<bool> DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await unitOfWork.Products.GetByIdAsync(id, cancellationToken);
        if (product == null)
        {
            return false;
        }

        await unitOfWork.Products.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ProductDetailsDto?> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await unitOfWork.Products.GetDetailsByIdAsync(id, cancellationToken);
        if (product == null)
        {
            return null;
        }
        return mapper.Map<ProductDetailsDto>(product);
    }

    public async Task<IEnumerable<ReadProductDto>> GetProductByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        var products = await unitOfWork.Products.FilterAsync(
            p => p.CategoryId == categoryId, 
            cancellationToken);

        return mapper.Map<IEnumerable<ReadProductDto>>(products);
    }
}