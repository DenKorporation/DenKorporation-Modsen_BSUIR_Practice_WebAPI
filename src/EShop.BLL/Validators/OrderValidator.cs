using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.BLL.Validators;

public class OrderValidator: AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.Address)
          .NotEmpty()
          .WithMessage("Address is empty.");
    }
}
