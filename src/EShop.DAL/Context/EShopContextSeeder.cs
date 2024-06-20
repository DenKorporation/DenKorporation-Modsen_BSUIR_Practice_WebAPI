using EShop.DAL.Entities;
using EShop.DAL.Enums;
using Microsoft.Extensions.Logging;

namespace EShop.DAL.Context;

public static class EShopContextSeeder
{
    public static async Task SeedAsync(EShopContext db, ILogger logger, CancellationToken cancellationToken = default)
    {
        try
        {
            await db.AddRangeAsync(GetPreconfiguredUsers(), cancellationToken);
            await db.AddRangeAsync(GetPreconfiguredCategories(), cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            await db.AddRangeAsync(GetPreconfiguredProducts(), cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            await db.AddRangeAsync(GetPreconfiguredOrders(), cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            await db.AddRangeAsync(GetPreconfiguredOrdersItems(), cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            logger.LogError("Failed to seed data");
            throw;
        }
    }

    private static IEnumerable<User> GetPreconfiguredUsers()
    {
        return new List<User>
        {
            new()
            {
                Id = new Guid("4C311A99-1F64-4821-829A-7F00371586EB"),
                Name = "John Doe",
                Email = "john@example.com",
            },
            new()
            {
                Id = new Guid("8F6C91CE-144F-40CA-943E-F42E131DD926"),
                Name = "Jane Smith",
                Email = "jane@example.com",
            }
        };
    }

    private static IEnumerable<Category> GetPreconfiguredCategories()
    {
        return new List<Category>
        {
            new() { Id = new Guid("46EB37A4-E418-4BEB-A455-926D6D0ACA88"), Name = "Electronics" },
            new() { Id = new Guid("FFB3E9CF-DE47-48F6-95B2-728BD3A472EF"), Name = "Groceries" },
            new() { Id = new Guid("66D11634-CD0D-4DB3-A17E-A6DC05AFBC00"), Name = "Clothing" },
            new() { Id = new Guid("B792C477-B462-4553-91AE-1A3578762DDF"), Name = "Books" },
            new() { Id = new Guid("4B8D23ED-A65A-4AC8-AB6C-ECEF8B4B9B3D"), Name = "Furniture" }
        };
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
        {
            // Electronics category
            new()
            {
                Id = new Guid("809831A0-836B-4E65-98F4-3BA708E44D25"),
                CategoryId = new Guid("46EB37A4-E418-4BEB-A455-926D6D0ACA88"),
                Name = "Laptop",
                Description = "High-performance laptop",
                Price = 999.99m,
                AvailableStock = 50
            },
            new()
            {
                Id = new Guid("E29B0D1C-344A-4382-A13E-7A4BA55A1CCC"),
                CategoryId = new Guid("46EB37A4-E418-4BEB-A455-926D6D0ACA88"),
                Name = "Smartphone",
                Description = "Latest model smartphone",
                Price = 799.99m,
                AvailableStock = 100
            },
            new()
            {
                Id = new Guid("EEDAD1BA-67BC-4E87-8B98-E87C7FCC0151"),
                CategoryId = new Guid("46EB37A4-E418-4BEB-A455-926D6D0ACA88"),
                Name = "Tablet",
                Description = "Lightweight and portable tablet",
                Price = 499.99m,
                AvailableStock = 75
            },
            // Groceries category
            new()
            {
                Id = new Guid("732A0A3C-2A55-424E-8EB7-86C8599C9A4F"),
                CategoryId = new Guid("FFB3E9CF-DE47-48F6-95B2-728BD3A472EF"),
                Name = "Apple",
                Description = "Fresh red apple",
                Price = 0.99m,
                AvailableStock = 500
            },
            new()
            {
                Id = new Guid("A4DAB551-753B-46ED-8AA6-0EA64CD59749"),
                CategoryId = new Guid("FFB3E9CF-DE47-48F6-95B2-728BD3A472EF"),
                Name = "Bread",
                Description = "Whole grain bread",
                Price = 2.49m,
                AvailableStock = 200
            },
            new()
            {
                Id = new Guid("1C1EA459-891F-4F8B-9282-8E5FDFE86099"),
                CategoryId = new Guid("FFB3E9CF-DE47-48F6-95B2-728BD3A472EF"),
                Name = "Milk",
                Description = "1 gallon of milk",
                Price = 3.99m,
                AvailableStock = 150
            },
            // Clothing category
            new()
            {
                Id = new Guid("C2164019-4D1D-4A47-B86E-BC6F7EE45BEC"),
                CategoryId = new Guid("66D11634-CD0D-4DB3-A17E-A6DC05AFBC00"),
                Name = "T-Shirt",
                Description = "Cotton T-Shirt",
                Price = 14.99m,
                AvailableStock = 100
            },
            new()
            {
                Id = new Guid("51BFAFBF-3052-43D2-B144-5D3E7167020B"),
                CategoryId = new Guid("66D11634-CD0D-4DB3-A17E-A6DC05AFBC00"),
                Name = "Jeans",
                Description = "Denim jeans",
                Price = 49.99m,
                AvailableStock = 60
            },
            new()
            {
                Id = new Guid("FA96058E-907F-4799-AC32-9F45172CDEFB"),
                CategoryId = new Guid("66D11634-CD0D-4DB3-A17E-A6DC05AFBC00"),
                Name = "Jacket",
                Description = "Waterproof jacket",
                Price = 89.99m,
                AvailableStock = 40
            },
            // Books category
            new()
            {
                Id = new Guid("9081E5FF-E1E5-4972-9CE9-68D4F5DF65DB"),
                CategoryId = new Guid("B792C477-B462-4553-91AE-1A3578762DDF"),
                Name = "Fiction",
                Description = "Bestselling fiction book",
                Price = 19.99m,
                AvailableStock = 80
            },
            new()
            {
                Id = new Guid("CE38D4F2-7BE2-4CD9-A28F-DF5CF45A3BAA"),
                CategoryId = new Guid("B792C477-B462-4553-91AE-1A3578762DDF"),
                Name = "Non-Fiction",
                Description = "Informative non-fiction book",
                Price = 24.99m,
                AvailableStock = 70
            },
            new()
            {
                Id = new Guid("D466737F-7C29-482C-AEB1-4100D804B30F"),
                CategoryId = new Guid("B792C477-B462-4553-91AE-1A3578762DDF"),
                Name = "Science",
                Description = "Educational science book",
                Price = 29.99m,
                AvailableStock = 60
            },
            // Furniture category
            new()
            {
                Id = new Guid("D62836D7-C920-49A4-86D2-F05E2A3DF3E4"),
                CategoryId = new Guid("4B8D23ED-A65A-4AC8-AB6C-ECEF8B4B9B3D"),
                Name = "Table",
                Description = "Wooden dining table",
                Price = 199.99m,
                AvailableStock = 20
            },
            new()
            {
                Id = new Guid("133B9DEB-5BF0-4246-9573-08EA6C05FE9A"),
                CategoryId = new Guid("4B8D23ED-A65A-4AC8-AB6C-ECEF8B4B9B3D"),
                Name = "Chair",
                Description = "Comfortable chair",
                Price = 49.99m,
                AvailableStock = 50
            },
            new()
            {
                Id = new Guid("8D67D030-BF64-4364-8715-5861D037A24B"),
                CategoryId = new Guid("4B8D23ED-A65A-4AC8-AB6C-ECEF8B4B9B3D"),
                Name = "Sofa",
                Description = "Three-seater sofa",
                Price = 399.99m,
                AvailableStock = 15
            }
        };
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
        {
            new()
            {
                Id = new Guid("6E61AC4C-1833-40BA-BF58-AEE8831BD0AC"),
                CustomerId = new Guid("8F6C91CE-144F-40CA-943E-F42E131DD926"),
                OrderDate = DateTime.UtcNow,
                Address = "456 Elm St",
                Commentary = "Deliver to the back door",
                OrderStatus = OrderStatus.Shipped,
            },
            new()
            {
                Id = new Guid("A90AB004-F61B-4843-B0B9-D829846373C0"),
                CustomerId = new Guid("4C311A99-1F64-4821-829A-7F00371586EB"),
                OrderDate = DateTime.UtcNow,
                Address = "123 Main St",
                Commentary = "Leave at the door",
                OrderStatus = OrderStatus.Submitted,
            }
        };
    }

    private static IEnumerable<OrderItem> GetPreconfiguredOrdersItems()
    {
        return new List<OrderItem>
        {
            // first order
            new()
            {
                Id = new Guid("2D4A5941-F102-421A-AAD0-7B468A0173B8"),
                ProductId = new Guid("732A0A3C-2A55-424E-8EB7-86C8599C9A4F"),
                OrderId = new Guid("6E61AC4C-1833-40BA-BF58-AEE8831BD0AC"),
                Quantity = 1
            },
            new()
            {
                Id = new Guid("30C73FA8-BA99-4307-BF68-C5F0D45E5046"),
                ProductId = new Guid("1C1EA459-891F-4F8B-9282-8E5FDFE86099"),
                OrderId = new Guid("6E61AC4C-1833-40BA-BF58-AEE8831BD0AC"),
                Quantity = 2
            },
            // second order
            new()
            {
                Id = new Guid("361C081B-95F2-42D3-840E-E610407A6D14"),
                ProductId = new Guid("D466737F-7C29-482C-AEB1-4100D804B30F"),
                OrderId = new Guid("A90AB004-F61B-4843-B0B9-D829846373C0"),
                Quantity = 1
            },
            new()
            {
                Id = new Guid("5AE62E4B-F407-4FA5-8069-F696AA47F233"),
                ProductId = new Guid("9081E5FF-E1E5-4972-9CE9-68D4F5DF65DB"),
                OrderId = new Guid("A90AB004-F61B-4843-B0B9-D829846373C0"),
                Quantity = 1
            }
        };
    }
}