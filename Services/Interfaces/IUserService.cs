using KDSOrderManagement.Models;

namespace KDSOrderManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateAsync(UserDto userDto);
        Task<string> AuthenticateAsync(UserDto userDto);
    }
}
