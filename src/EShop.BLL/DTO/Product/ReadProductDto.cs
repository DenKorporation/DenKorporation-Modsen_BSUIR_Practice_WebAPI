namespace EShop.BLL.DTO.Product;

public class ReadProductDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public uint AvailableStock { get; set; }
    
    public Guid CategoryId { get; set; }
}