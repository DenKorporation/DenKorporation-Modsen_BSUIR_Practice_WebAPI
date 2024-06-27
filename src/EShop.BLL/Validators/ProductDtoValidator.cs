using EShop.BLL.DTO.Product;
using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.BLL.Validators;

public class ProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(product => product.Name)
          .NotEmpty()
          .WithMessage("Name is empty.");
        RuleFor(product => product.Description)
          .NotEmpty()
          .WithMessage("Description is empty.");
    }
}
