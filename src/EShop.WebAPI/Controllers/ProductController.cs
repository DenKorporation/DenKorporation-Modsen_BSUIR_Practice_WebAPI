using EShop.BLL.DTO.OrderItem;
using EShop.BLL.DTO.Product;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("category/{categoryId:guid}")]
    public Task<IActionResult> GetProductsByCategoryAsync(
        Guid categoryId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<IActionResult> CreateProductAsync(
        [FromBody] CreateProductDto model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateProductAsync(
        Guid id, [FromBody] UpdateProductDto model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task<IActionResult> DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
