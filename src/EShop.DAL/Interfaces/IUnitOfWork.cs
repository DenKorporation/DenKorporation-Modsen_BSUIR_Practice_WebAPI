namespace EShop.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Categories { get; }
    IOrderRepository Orders { get; }
    IOrderItemRepository OrderItems { get; }
    IProductRepository Products { get; }
    IUserRepository Users { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}