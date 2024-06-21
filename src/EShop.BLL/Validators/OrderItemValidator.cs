using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.BLL.Validators;

public class OrderItemValidator: AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {         
    }
}
