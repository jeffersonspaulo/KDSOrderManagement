using KDSOrderManagement.Data;
using KDSOrderManagement.Data.Repositories;
using KDSOrderManagement.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KDSOrderManagement.Configurations
{
    public static class ApplicationConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
