using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
