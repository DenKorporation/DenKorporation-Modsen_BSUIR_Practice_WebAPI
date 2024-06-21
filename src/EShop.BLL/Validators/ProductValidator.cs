using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.BLL.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
        RuleFor(product => product.Description)
          .NotEmpty()
          .WithMessage("Description is empty.");
    }
}
