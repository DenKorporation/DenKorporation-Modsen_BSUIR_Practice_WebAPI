using EShop.BLL.DTO.Order;
using EShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        var orders = await _orderService.GetOrdersAsync(cancellationToken);

        return Ok(orders);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await _orderService.GetOrderById(id, cancellationToken);

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var orders = await _orderService.GetUserOrdersAsync(userId, cancellationToken);

        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(
        [FromBody] CreateOrderDto model, CancellationToken cancellationToken = default)
    {
        var order = await _orderService.CreateOrderAsync(model, cancellationToken);

        if (order is null)
        {
            return BadRequest();
        }

        return Created();
    }
}
