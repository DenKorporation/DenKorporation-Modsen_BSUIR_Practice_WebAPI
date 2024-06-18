using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface IOrderItemRepository
{
    Task<OrderItem> AddOrderItem(OrderItem orderItem);
    Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
    Task<OrderItem> GetOrderItemById(int id);
    Task DeleteOrderItemById(int id);

    Task<IEnumerable<OrderItem>> GetAllOrderItems();
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrder(Order order);
}
