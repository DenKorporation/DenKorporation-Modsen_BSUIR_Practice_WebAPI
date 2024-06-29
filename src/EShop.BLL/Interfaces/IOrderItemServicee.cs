using EShop.BLL.DTO.OrderItem;

namespace EShop.BLL.Interfaces;

public interface IOrderItemService
{
    Task<ReadOrderItemDto?> CreateOrderItemAsync(
        CreateOrderItemDto orderItemDto, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<ReadOrderItemDto>> GetOrderItemsAsync(
        CancellationToken cancellationToken = default);
    
    Task<ReadOrderItemDto?> UpdateOrderItemAsync(
        Guid id, CreateOrderItemDto orderItemDto, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteOrderItemAsync(
        Guid id, CancellationToken cancellationToken = default);
    
    Task<ReadOrderItemDto?> GetOrderItemByIdAsync(
        Guid id, CancellationToken cancellationToken = default);
}