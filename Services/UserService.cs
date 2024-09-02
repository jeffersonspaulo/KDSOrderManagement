using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Services.Interfaces;

namespace KDSOrderManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration, ITokenService tokenService, IUserRepository userRepository)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
                return null; 

            return _tokenService.GenerateToken(user);
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
