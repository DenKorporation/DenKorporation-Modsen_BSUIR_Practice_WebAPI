using AutoMapper;
using EShop.BLL.DTO.Order;
using EShop.BLL.Interfaces;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using FluentValidation;

namespace EShop.BLL.Services;

public class OrderService(IMapper mapper, IUnitOfWork unitOfWork,AbstractValidator<Order> validator) : IOrderService
{
    public async Task<ReadOrderDto?> CreateOrderAsync(CreateOrderDto orderDto, CancellationToken cancellationToken = default)
    {
        if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));

        var order = mapper.Map<Order>(orderDto);

        var validationResult = await validator.ValidateAsync(order);

        if (!validationResult.IsValid)
        { throw new Exception("Order data has not been validated");
           
        }

        var createdOrder = await unitOfWork.Orders.AddAsync(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<ReadOrderDto>(createdOrder);
    }
    

    public async Task<IEnumerable<ReadOrderDto>> GetUserOrdersAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var orders = await unitOfWork.Orders.FilterAsync(
            p => p.CustomerId == userId, 
            cancellationToken);

        return mapper.Map<IEnumerable<ReadOrderDto>>(orders);
    }
    

    public async Task<IEnumerable<ReadOrderDto>> GetOrdersAsync(CancellationToken cancellationToken = default)
    {
        var categories = await unitOfWork.Orders.GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ReadOrderDto>>(categories);
    }

    public async Task<ReadOrderDto?> UpdateOrderAsync(Guid id, CreateOrderDto orderDto, CancellationToken cancellationToken = default)
    {
        if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));
        var order = mapper.Map<Order>(orderDto);

        var validationResult = await validator.ValidateAsync(order);

        if (!validationResult.IsValid)
        {
            throw new Exception("Order data has not been validated");
        }
        
        var orderDb = await unitOfWork.Orders.GetByIdAsync(id, cancellationToken);
        if (orderDb == null)
        {
            return null;
        }

        orderDb.OrderDate = order.OrderDate;
        orderDb.Address = order.Address;
        orderDb.OrderStatus = order.OrderStatus;
        orderDb.Commentary = order.Commentary;
        orderDb.CustomerId = order.CustomerId;
        
        await unitOfWork.Orders.Update(orderDb);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<ReadOrderDto>(orderDb);
    }

    public async Task<bool> DeleteOrderAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await unitOfWork.Orders.GetByIdAsync(id, cancellationToken);
        if (order == null)
        {
            return false;
        }

        await unitOfWork.Orders.DeleteAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<OrderDetailsDto?> GetOrderByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await unitOfWork.Orders.GetDetailsByIdAsync(id, cancellationToken);
        if (order == null)
        {
            return null;
        }
        return mapper.Map<OrderDetailsDto>(order);
    }
}