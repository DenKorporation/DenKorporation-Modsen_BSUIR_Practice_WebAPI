namespace EShop.BLL.DTO.OrderItem;

public class ReadOrderItemDto
{
    public Guid Id { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Guid OrderId { get; set; }
    
    public uint Quantity { get; set; }
}