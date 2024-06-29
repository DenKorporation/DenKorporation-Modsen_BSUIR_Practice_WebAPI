using EShop.BLL.DTO.User;
using FluentValidation;
using EShop.DAL.Entities;

namespace EShop.BLL.Validators;

public class UserDtoValidator: AbstractValidator<UserRequestDto>
{
    public UserDtoValidator()
    {
        RuleFor(user => user.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
        RuleFor(user => user.Email)
          .NotEmpty()
          .WithMessage("Email is empty.");
        RuleFor(user => user.PasswordHash)
            .MinimumLength(6)
            .When(user => user.PasswordHash is not null)
            .WithMessage("Password must contain at least 6 characters.");
    }
}
