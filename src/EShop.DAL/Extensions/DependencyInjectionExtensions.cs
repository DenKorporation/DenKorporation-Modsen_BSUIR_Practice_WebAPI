using EShop.DAL.Context;
using EShop.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.DAL.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EShopContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("Database")));
        
        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<EShopContext>();

        return services;
    }
}