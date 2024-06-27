using EShop.BLL.DTO.OrderItem;
using FluentValidation;

namespace EShop.BLL.Validators;

public class OrderItemDtoValidator: AbstractValidator<CreateOrderItemDto>
{
    public OrderItemDtoValidator()
    {         
    }
}
