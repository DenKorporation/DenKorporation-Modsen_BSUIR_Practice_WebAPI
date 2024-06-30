using EShop.BLL.DTO.User;
using FluentValidation;

namespace EShop.BLL.Validators;

public class UserLoginDtoValidator: AbstractValidator<LoginUserDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is empty.");
        RuleFor(user => user.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is empty.");
        RuleFor(user => user.PasswordHash)
            .MinimumLength(6)
            .WithMessage("Password must contain at least 6 characters.");
    }   
}