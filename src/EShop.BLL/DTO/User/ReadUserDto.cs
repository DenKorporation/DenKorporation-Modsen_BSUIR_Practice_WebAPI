namespace EShop.BLL.DTO.User;

public class ReadUserDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
}