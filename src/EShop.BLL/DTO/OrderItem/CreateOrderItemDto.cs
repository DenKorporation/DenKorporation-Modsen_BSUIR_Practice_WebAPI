namespace EShop.BLL.DTO.OrderItem;

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }
    
    public uint Quantity { get; set; }
}