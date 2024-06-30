using EShop.DAL.Context;
using EShop.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EShop.DAL.Extensions;

public static class DatabaseExtensions
{
    public static async Task<IHost> ApplyMigrationAsync(this IHost app, CancellationToken cancellationToken = default)
    {
        using var scope = app.Services.CreateScope();
        var scopedContext = scope.ServiceProvider.GetRequiredService<EShopContext>();
        await scopedContext.Database.MigrateAsync(cancellationToken: cancellationToken);

        return app;
    }
    
    public static async Task<IHost> EnsureDeletedAsync(this IHost app, CancellationToken cancellationToken = default)
    {
        using var scope = app.Services.CreateScope();
        var scopedContext = scope.ServiceProvider.GetRequiredService<EShopContext>();
        await scopedContext.Database.EnsureDeletedAsync(cancellationToken);

        return app;
    }
    
    public static async Task<IHost> SeedAsync(this IHost app, ILogger logger, CancellationToken cancellationToken = default)
    {
        using var scope = app.Services.CreateScope();
        var scopedContext = scope.ServiceProvider.GetRequiredService<EShopContext>();
        var scopedUserManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        await EShopContextSeeder.SeedAsync(scopedContext, logger, scopedUserManager, cancellationToken);

        return app;
    }
}