using EShop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.DAL.Extensions;

public static class ServiceExtensions
{
    public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EShopContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("Database")));
    }
}