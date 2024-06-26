using System.Net;
using EShop.BLL.DTO.Category;
using EShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _categoryService.GetCategoriesAsync(cancellationToken);

        return Ok(categories);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);

        if (category is null)
        {
            return NotFound();
        }
        
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(
        [FromBody] CreateCategoryDto model, CancellationToken cancellationToken = default)
    {
        var category = await _categoryService.CreateCategoryAsync(model, cancellationToken);

        if (category is null)
        {
            return BadRequest();
        }

        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategoryAsync(
        Guid id, [FromBody] UpdateCategoryDto model, CancellationToken cancellationToken = default)
    {
        var category = await _categoryService.UpdateCategoryAsync(id, model, cancellationToken);

        if (category is null)
        {
            return BadRequest();
        }
        
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var isSuccess = await _categoryService.DeleteCategoryAsync(id, cancellationToken);

        if (!isSuccess)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
