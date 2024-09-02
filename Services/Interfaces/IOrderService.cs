using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int id);
        Task<OrderItem> AddItemToOrderAsync(int id, OrderItem item);
        Task UpdateOrderItemAsync(OrderItem item);
        Task DeleteOrderItemAsync(int id, int itemId);
    }
}
