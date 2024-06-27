using EShop.BLL.DTO.OrderItem;
using EShop.BLL.DTO.Product;
using EShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetProductsAsync(cancellationToken);

        return Ok(products);
    }

    [HttpGet("category/{categoryId:guid}")]
    public async Task<IActionResult> GetProductsByCategoryAsync(
        Guid categoryId, CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetProductByCategoryAsync(categoryId, cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetProductByIdAsync(id, cancellationToken);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(
        [FromBody] CreateProductDto model, CancellationToken cancellationToken = default)
    {
        var product = await _productService.CreateProductAsync(model, cancellationToken);

        if (product is null)
        {
            return BadRequest();
        }

        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProductAsync(
        Guid id, [FromBody] UpdateProductDto model, CancellationToken cancellationToken = default)
    {
        var product = await _productService.UpdateProductAsync(id, model, cancellationToken);

        if (product is null)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var isSuccess = await _productService.DeleteProductAsync(id, cancellationToken);

        if (!isSuccess)
        {
            return NotFound();
        }

        return NoContent();
    }
}
