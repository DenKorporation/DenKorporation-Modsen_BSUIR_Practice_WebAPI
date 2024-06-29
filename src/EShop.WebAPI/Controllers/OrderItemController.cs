using EShop.BLL.DTO.OrderItem;
using EShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    
    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderItemsAsync(CancellationToken cancellationToken = default)
    {
        var orderItems = await _orderItemService.GetOrderItemsAsync(cancellationToken);

        return Ok(orderItems);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderItemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var orderItem = await _orderItemService.GetOrderItemByIdAsync(id, cancellationToken);

        if (orderItem is null)
        {
            return NotFound();
        }

        return Ok(orderItem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderItemAsync(
        [FromBody] CreateOrderItemDto model, CancellationToken cancellationToken = default)
    {
        var orderItem = await _orderItemService.CreateOrderItemAsync(model, cancellationToken);

        if (orderItem is null)
        {
            return NotFound();
        }

        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateOrderItemAsync(
        Guid id, [FromBody] UpdateOrderItemDto model, CancellationToken cancellationToken = default)
    {
        var orderItem = await _orderItemService.UpdateOrderItemAsync(id, model, cancellationToken);

        if (orderItem is null)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrderItemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var isSuccess = await _orderItemService.DeleteOrderItemAsync(id, cancellationToken);

        if (!isSuccess)
        {
            return NotFound();
        }

        return NoContent();
    }
}