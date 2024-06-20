using FluentValidation;
using EShop.DAL.Entities;
namespace EShop.WebAPI.Validators;

public class UserValidator: AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
        RuleFor(user => user.Email)
          .NotEmpty()
          .WithMessage("Email is empty.");
    }
}
