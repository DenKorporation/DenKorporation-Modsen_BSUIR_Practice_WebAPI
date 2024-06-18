namespace EShop.DAL.Entities;

public class OrderItem
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }
   
    public Guid OrderId { get; set; }

    public uint Quantity { get; set; }
    
    
    public Product Product { get; set; } = null!;

    public Order Order { get; set; } = null!;
}