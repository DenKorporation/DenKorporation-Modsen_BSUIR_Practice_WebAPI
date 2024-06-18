using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces;

public interface IUserRepository
{
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> GetUserById(int id);
    Task DeleteUserById(int id);

    Task<IEnumerable<User>> GetAllUser();
}
