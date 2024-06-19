using EShop.BLL.DTO.Order;

namespace EShop.BLL.DTO.User;

public class UserDetailsDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public ICollection<ReadOrderDto> Orders { get; set; } = new List<ReadOrderDto>();
}