using KDSOrderManagement.Models;
using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> CreateAsync(OrderDto orderDto);
        Task UpdateAsync(int id, OrderDto orderDto);
        Task DeleteAsync(int id);
        
    }
}
