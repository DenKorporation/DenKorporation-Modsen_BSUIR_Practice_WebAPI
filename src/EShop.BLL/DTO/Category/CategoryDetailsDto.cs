using EShop.BLL.DTO.Product;

namespace EShop.BLL.DTO.Category;

public class CategoryDetailsDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;

    public ICollection<ReadProductDto> Products { get; set; } = null!;
}