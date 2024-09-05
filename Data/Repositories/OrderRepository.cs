using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDSOrderManagement.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context) : base(context)
        {
            _context = context;
        }
    }
}
