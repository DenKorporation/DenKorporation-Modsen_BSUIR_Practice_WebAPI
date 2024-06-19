using EShop.DAL.Enums;

namespace EShop.BLL.DTO.Order;

public class ReadOrderDto
{
    public Guid Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public string Address { get; set; } = null!;
    
    public string? Commentary { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
}