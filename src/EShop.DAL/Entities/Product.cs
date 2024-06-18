namespace EShop.DAL.Entities;

public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public uint AvailableStock { get; set; }
    
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;
    
    public ICollection<OrderItem> OrderItems { get; set; } = null!;
}