using EShop.BLL.DTO.Order;
using EShop.BLL.DTO.Product;

namespace EShop.BLL.DTO.OrderItem;

public class OrderItemDetailsDto
{
    public Guid Id { get; set; }

    public ReadOrderDto Order { get; set; } = null!;
    
    public uint Quantity { get; set; }
    
    public ReadProductDto Product { get; set; } = null!;
}