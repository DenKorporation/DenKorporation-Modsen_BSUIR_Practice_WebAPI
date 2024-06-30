using EShop.BLL.DTO.User;
using FluentValidation;

namespace EShop.BLL.Validators;

public class UserRegisterDtoValidator: AbstractValidator<RegisterUserDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage("Name is empty.");
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is empty.");
        RuleFor(user => user.PasswordHash)
            .MinimumLength(6)
            .WithMessage("Password must contain at least 6 characters.");
    }
}