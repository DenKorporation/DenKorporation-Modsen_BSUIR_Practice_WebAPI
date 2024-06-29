using AutoMapper;
using EShop.BLL.DTO.OrderItem;
using EShop.BLL.DTO.Order;
using EShop.BLL.Interfaces;
using EShop.BLL.Validators;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using FluentValidation;

namespace EShop.BLL.Services;

public class OrderItemService(IMapper mapper, IUnitOfWork unitOfWork,AbstractValidator<CreateOrderItemDto> validator) : IOrderItemService
{
    public async Task<ReadOrderItemDto?> CreateOrderItemAsync(CreateOrderItemDto orderItemDto, CancellationToken cancellationToken = default)
    {
        if (orderItemDto == null) throw new ArgumentNullException(nameof(orderItemDto));
        
        var validationResult = await validator.ValidateAsync(orderItemDto);

        if (!validationResult.IsValid)
        { throw new Exception("OrderItem data has not been validated");
           
        }

        var orderItem = mapper.Map<OrderItem>(orderItemDto);
        var createdOrderItem = await unitOfWork.OrderItems.AddAsync(orderItem, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<ReadOrderItemDto>(createdOrderItem);
    }
    

    public async Task<IEnumerable<ReadOrderItemDto>> GetOrderItemsAsync(CancellationToken cancellationToken = default)
    {
        var orderItems = await unitOfWork.OrderItems.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ReadOrderItemDto>>(orderItems);
    }

    public async Task<ReadOrderItemDto?> UpdateOrderItemAsync(Guid id, CreateOrderItemDto orderItemDto, CancellationToken cancellationToken = default)
    {
        if (orderItemDto == null) throw new ArgumentNullException(nameof(orderItemDto));
        
        var validationResult = await validator.ValidateAsync(orderItemDto);

        if (!validationResult.IsValid)
        {
            throw new Exception("OrderItem data has not been validated");
        }
        
        var orderItem = mapper.Map<OrderItem>(orderItemDto);
        var orderItemDb = await unitOfWork.OrderItems.GetByIdAsync(id, cancellationToken);
        if (orderItemDb == null)
        {
            return null;
        }

        orderItemDb.Quantity = orderItem.Quantity;
        orderItemDb.OrderId = orderItem.OrderId;
        orderItemDb.ProductId = orderItem.ProductId;
        
        await unitOfWork.OrderItems.Update(orderItemDb);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadOrderItemDto>(orderItemDb);
    }

    public async Task<bool> DeleteOrderItemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var orderItem = await unitOfWork.OrderItems.GetByIdAsync(id, cancellationToken);
        if (orderItem == null)
        {
            return false;
        }

        await unitOfWork.OrderItems.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ReadOrderItemDto?> GetOrderItemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var orderItem = await unitOfWork.OrderItems.GetByIdAsync(id, cancellationToken);
        return orderItem == null ? null : mapper.Map<ReadOrderItemDto>(orderItem);
    }
}