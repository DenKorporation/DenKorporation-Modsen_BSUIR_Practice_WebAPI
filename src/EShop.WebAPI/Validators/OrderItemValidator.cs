using EShop.DAL.Entities;
using FluentValidation;

namespace EShop.WebAPI.Validators
{
    public class OrderItemValidator: AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {         
        }
    }
}
