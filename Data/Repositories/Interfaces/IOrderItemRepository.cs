using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Data.Repositories.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId);
        Task<OrderItem> AddItemAsync(int orderId, OrderItem item);
        Task UpdateItemAsync(OrderItem item);
        Task DeleteItemAsync(int orderId, int itemId);
    }
}
