using EShop.DAL.Context;
using EShop.DAL.Interfaces;

namespace EShop.DAL.Repositories;

public class UnitOfWork(EShopContext _appDbContext) : IUnitOfWork
{

    private CategoryRepository _categoryRepository;
    
    private OrderRepository _orderRepository;
    
    private OrderItemRepository _orderItemRepository;
    
    private ProductRepository _productRepository;
    
    private UserRepository _userRepository;
    
    public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_appDbContext);
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_appDbContext);
    public IOrderItemRepository OrderItems => _orderItemRepository ??= new OrderItemRepository(_appDbContext);
    public IProductRepository Products => _productRepository ??= new ProductRepository(_appDbContext);
    public IUserRepository Users => _userRepository ??= new UserRepository(_appDbContext);
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    private bool _disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }

            this._disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}