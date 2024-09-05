using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDSOrderManagement.Data.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly OrderContext _context;

        public OrderItemRepository(OrderContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetItemsByOrderIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Include(item => item.Order)
                .Where(item => item.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<OrderItem> AddItemAsync(int orderId, OrderItem item)
        {
            item.OrderId = orderId;
            await _context.OrderItems.AddAsync(item);
            await _context.SaveChangesAsync();

            var addedItem = await _context.OrderItems
                .Include(i => i.Order)
                .SingleOrDefaultAsync(i => i.Id == item.Id);

            return addedItem;
        }

        public async Task UpdateItemAsync(OrderItem item)
        {
            _context.OrderItems.Attach(item);
            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int orderId, int itemId)
        {
            var item = await _context.OrderItems.FirstOrDefaultAsync(item => item.OrderId == orderId && item.Id == itemId);

            if (item != null)
            {
                _context.OrderItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
