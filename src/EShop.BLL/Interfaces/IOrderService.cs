using EShop.BLL.DTO.Order;

namespace EShop.BLL.Interfaces;

public interface IOrderService
{
    Task<ReadOrderDto?> CreateOrderAsync(
        CreateOrderDto orderDto, CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadOrderDto>> GetOrdersAsync(
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ReadOrderDto>> GetUserOrdersAsync(
        Guid userId, CancellationToken cancellationToken = default);

    Task<OrderDetailsDto?> GetOrderById(
        Guid id, CancellationToken cancellationToken = default);
}