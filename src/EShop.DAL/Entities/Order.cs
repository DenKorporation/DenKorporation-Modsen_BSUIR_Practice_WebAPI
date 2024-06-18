using EShop.DAL.Enums;

namespace EShop.DAL.Entities;

public class Order
{
    public Guid Id { get; set; }
    
    public DateTime OrderDate { get; set; }

    public string Address { get; set; } = null!;
    
    public string? Commentary { get; set; }

    public Guid CustomerId { get; set; }
    
    public OrderStatus OrderStatus { get; set; }
    
    public User Customer { get; set; } = null!;
    
    public ICollection<OrderItem> OrderItems { get; set; } = null!;
}