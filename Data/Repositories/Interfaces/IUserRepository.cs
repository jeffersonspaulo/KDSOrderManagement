using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
