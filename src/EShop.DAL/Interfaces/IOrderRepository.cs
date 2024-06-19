using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

internal interface IOrderRepository: IBaseRepository<Order, int>
{
    Task<IEnumerable<Order>> GetOrdersByUser(User user);
}
