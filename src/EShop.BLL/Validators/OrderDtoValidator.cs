using EShop.BLL.DTO.Order;
using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.BLL.Validators;

public class OrderDtoValidator: AbstractValidator<CreateOrderDto>
{
    public OrderDtoValidator()
    {
        RuleFor(order => order.Address)
          .NotEmpty()
          .WithMessage("Address is empty.");
    }
}
