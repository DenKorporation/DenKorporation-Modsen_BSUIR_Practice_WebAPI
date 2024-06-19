using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface IOrderItemRepository: IBaseRepository<OrderItem, int>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrder(Order order);
}
