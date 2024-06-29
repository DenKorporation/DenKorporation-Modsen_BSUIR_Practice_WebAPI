using AutoMapper;
using EShop.BLL.DTO.User;
using EShop.BLL.Exceptions;
using EShop.BLL.Interfaces;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EShop.BLL.Services;

public class UserService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<User> userManager) : IUserService
{
    
    public async Task<ReadUserDto> Login(LoginUserDto userDto, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByEmailAsync(userDto.Email);

        if (user is null)
        {
            throw new LoginFailedException();
        }
        
        if (!await userManager.CheckPasswordAsync(user, userDto.PasswordHash))
        {
            throw new LoginFailedException();
        }

        return mapper.Map<ReadUserDto>(user);
    }

    public async Task<ReadUserDto> Register(RegisterUserDto userDto, CancellationToken cancellationToken = default)
    {
        if (userDto == null) throw new ArgumentNullException(nameof(userDto));
        
        var user = mapper.Map<User>(userDto);

        var createResult = await userManager.CreateAsync(user);
        if (!createResult.Succeeded)
        {
            throw new RegistrationFailedException(errors: createResult.Errors);
        }

        var userDb = await userManager.FindByEmailAsync(user.Email!);
        
        var passwordResult = await userManager.AddPasswordAsync(userDb!, userDto.PasswordHash);
        if (!passwordResult.Succeeded)
        {
            throw new RegistrationFailedException(errors: passwordResult.Errors);
        }

        return mapper.Map<ReadUserDto>(userDb);
    }

    public async Task<IEnumerable<ReadUserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await unitOfWork.Users.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ReadUserDto>>(users);
    }

    public async Task<UserDetailsDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await unitOfWork.Users.GetByIdAsync(id, cancellationToken);
        return user == null ? null : mapper.Map<UserDetailsDto>(user);
    }

    public async Task<ReadUserDto?> UpdateProductAsync(Guid id, UserRequestDto userDto, CancellationToken cancellationToken = default)
    {
        if (userDto == null) throw new ArgumentNullException(nameof(userDto));
                
        var userDb = await unitOfWork.Users.GetByIdAsync(id, cancellationToken);
        if (userDb == null)
        {
            return null;
        }

        userDb.UserName = userDto.Name;
        userDb.Email = userDto.Email;
        if (userDto.PasswordHash is not null)
        {
            userDb.PasswordHash = userDto.PasswordHash;
        }
        
        await unitOfWork.Users.Update(userDb);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadUserDto>(userDb);
    }

    public async Task<bool> DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await unitOfWork.OrderItems.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            return false;
        }

        await unitOfWork.OrderItems.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}