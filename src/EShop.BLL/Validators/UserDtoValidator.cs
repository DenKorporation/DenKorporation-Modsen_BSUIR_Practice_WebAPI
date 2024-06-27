using EShop.BLL.DTO.User;
using FluentValidation;
using EShop.DAL.Entities;

namespace EShop.BLL.Validators;

public class UserDtoValidator: AbstractValidator<CreateUserDto>
{
    public UserDtoValidator()
    {
        RuleFor(user => user.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
        RuleFor(user => user.Email)
          .NotEmpty()
          .WithMessage("Email is empty.");
    }
}
