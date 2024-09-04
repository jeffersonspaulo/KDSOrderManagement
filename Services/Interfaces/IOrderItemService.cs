using KDSOrderManagement.Models;
using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int id);
        Task<OrderItem> AddItemToOrderAsync(int orderId, OrderItemDto orderItemDto);
        Task UpdateOrderItemAsync(int orderId, int orderItemId, OrderItemDto orderItemDto);
        Task DeleteOrderItemAsync(int id, int itemId);
    }
}
