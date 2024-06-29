using EShop.BLL.DTO.Category;
using FluentValidation;

namespace EShop.BLL.Validators;

public class CategoryDtoValidator: AbstractValidator<CreateCategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(category => category.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
    }
}
