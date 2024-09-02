namespace KDSOrderManagement.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
