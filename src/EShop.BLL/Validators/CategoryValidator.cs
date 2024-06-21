using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.BLL.Validators;

public class CategoryValidator: AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
    }
}
