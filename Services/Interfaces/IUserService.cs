using KDSOrderManagement.Models.Dtos;

namespace KDSOrderManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> CreateAsync(UserDto userDto);
        Task<string> AuthenticateAsync(UserDto userDto);
    }
}
