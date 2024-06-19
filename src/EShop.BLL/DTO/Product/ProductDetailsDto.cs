using EShop.BLL.DTO.Category;
using EShop.BLL.DTO.OrderItem;

namespace EShop.BLL.DTO.Product;

public class ProductDetailsDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public uint AvailableStock { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public ReadCategoryDto Category { get; set; } = null!;
    
    public ICollection<ReadOrderItemDto> OrderItems { get; set; } = null!;
}