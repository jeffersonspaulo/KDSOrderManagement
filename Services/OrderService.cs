using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Entities;
using KDSOrderManagement.Services.Interfaces;

namespace KDSOrderManagement.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> CreateAsync(Order order)
        {
            return await _orderRepository.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int id)
        {
            return await _orderRepository.GetItemsByOrderIdAsync(id);
        }

        public async Task<OrderItem> AddItemToOrderAsync(int id, OrderItem item)
        {
            return await _orderRepository.AddItemAsync(id, item);
        }

        public async Task UpdateOrderItemAsync(OrderItem item)
        {
            await _orderRepository.UpdateItemAsync(item);
        }

        public async Task DeleteOrderItemAsync(int id, int itemId)
        {
            await _orderRepository.DeleteItemAsync(id, itemId);
        }
    }
}
