using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KDSOrderManagement.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OrderContext _context;

        public UserRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
