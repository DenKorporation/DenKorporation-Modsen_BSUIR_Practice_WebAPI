using EShop.BLL.DTO.OrderItem;
using EShop.DAL.Enums;

namespace EShop.BLL.DTO.Order;

public class CreateOrderDto
{
    public DateTime OrderDate { get; set; }
    
    public string Address { get; set; } = null!;
    
    public string? Commentary { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }

    public ICollection<CreateOrderItemDto> OrderItems { get; set; } = null!;
}