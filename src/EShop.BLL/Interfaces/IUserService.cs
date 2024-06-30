using EShop.BLL.DTO.User;

namespace EShop.BLL.Interfaces;

public interface IUserService
{
    Task<ReadUserDto> Login(LoginUserDto userDto, CancellationToken cancellationToken = default);

    Task<ReadUserDto> Register(RegisterUserDto userDto, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ReadUserDto>> GetAllUsersAsync(
        CancellationToken cancellationToken = default);
    
    Task<UserDetailsDto?> GetUserByIdAsync(
        Guid id, CancellationToken cancellationToken = default);
    
    Task<ReadUserDto?> UpdateProductAsync(
        Guid id, UserRequestDto userDto, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteProductAsync(
        Guid id, CancellationToken cancellationToken = default);
}