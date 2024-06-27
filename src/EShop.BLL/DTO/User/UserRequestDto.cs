namespace EShop.BLL.DTO.User;

public class UserRequestDto
{
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string? PasswordHash { get; set; }
}