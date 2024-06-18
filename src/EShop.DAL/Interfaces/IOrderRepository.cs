using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

internal interface IOrderRepository
{
    Task<Order> AddOrder(Order order);
    Task<Order> UpdateOrder(Order order);
    Task<Order> GetOrderById(int id);
    Task DeleteOrderById(int id);

    Task<IEnumerable<Order>> GetAllOrder();
    Task<IEnumerable<Order>> GetOrdersByUser(User user);
}
