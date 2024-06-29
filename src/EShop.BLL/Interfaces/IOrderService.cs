using EShop.BLL.DTO.Order;

namespace EShop.BLL.Interfaces;

public interface IOrderService
{
    Task<ReadOrderDto?> CreateOrderAsync(
        CreateOrderDto orderDto, CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadOrderDto>> GetOrdersAsync(
        CancellationToken cancellationToken = default);
    
    Task<ReadOrderDto?> UpdateOrderAsync(
        Guid id, CreateOrderDto orderDto, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteOrderAsync(
        Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadOrderDto>> GetUserOrdersAsync(
        Guid userId, CancellationToken cancellationToken = default);

    Task<OrderDetailsDto?> GetOrderByIdAsync(
        Guid id, CancellationToken cancellationToken = default);
}