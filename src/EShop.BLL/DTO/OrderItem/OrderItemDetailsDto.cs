using EShop.BLL.DTO.Product;

namespace EShop.BLL.DTO.OrderItem;

public class OrderItemDetailsDto
{
    public Guid Id { get; set; }
    
    public Guid ProductId { get; set; }
    
    public uint Quantity { get; set; }
    
    public ReadProductDto Product { get; set; } = null!;
}