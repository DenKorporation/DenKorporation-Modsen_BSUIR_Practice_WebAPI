namespace EShop.DAL.Repositories;

public class UnitOfWork : IDisposable
{
    private EShopContext _appDbContext = new EShopContext();

    private CategoryRepository _categoryRepository;
    
    private OrderRepository _orderRepository;
    
    private OrderItemRepository _orderItemRepository;
    
    private ProductRepository _productRepository;
    
    private UserRepository _userRepository;

    public CategoryRepository Categories
    {
        get
        {
            if (_categoryRepository == null)
                _categoryRepository = new CategoryRepository(_appDbContext);
            return _categoryRepository;
        }
    }
    
    public OrderRepository Orders
    {
        get
        {
            if (_orderRepository == null)
                _orderRepository = new OrderRepository(_appDbContext);
            return _orderRepository;
        }
    }
    
    public OrderItemRepository OrderItems
    {
        get
        {
            if (_orderItemRepository == null)
                _orderItemRepository = new OrderItemRepository(_appDbContext);
            return _orderItemRepository;
        }
    }
    
    public ProductRepository Products
    {
        get
        {
            if (_productRepository == null)
                _productRepository = new ProductRepository(_appDbContext);
            return _productRepository;
        }
    }
    
    public UserRepository Users
    {
        get
        {
            if (_userRepository == null)
                _userRepository = new UserRepository(_appDbContext);
            return _userRepository;
        }
    }

    public async void SaveСhangesAsync(CancellationToken cancellationToken = default)
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