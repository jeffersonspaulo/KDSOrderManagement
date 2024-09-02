using KDSOrderManagement.Models.Entities;

namespace KDSOrderManagement.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
