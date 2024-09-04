using KDSOrderManagement.Data;
using KDSOrderManagement.Data.Repositories;
using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Services;
using KDSOrderManagement.Services.Interfaces;
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
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
