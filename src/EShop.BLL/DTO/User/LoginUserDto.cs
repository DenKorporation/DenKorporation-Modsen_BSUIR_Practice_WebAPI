namespace EShop.BLL.DTO.User;

public class LoginUserDto
{
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}