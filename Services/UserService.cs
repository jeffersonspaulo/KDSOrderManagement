using FluentValidation;
using KDSOrderManagement.Data.Repositories.Interfaces;
using KDSOrderManagement.Models.Dtos;
using KDSOrderManagement.Models.Entities;
using KDSOrderManagement.Services.Interfaces;
using KDSOrderManagement.Validators;
using System.Security.Cryptography;

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

        public async Task<string> CreateAsync(UserDto userDto)
        {
            var validator = new UserValidator();
            var resultValidator = validator.Validate(userDto);

            if (!resultValidator.IsValid)
            {
                throw new ValidationException(resultValidator.Errors);
            }

            var existingUser = await _userRepository.GetByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                throw new Exception("User already exists.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var user = new User
            {
                Username = userDto.Username,
                PasswordHash = passwordHash
            };

            await _userRepository.AddAsync(user);

            var token = _tokenService.GenerateToken(user);

            return token;

        }

        public async Task<string> AuthenticateAsync(UserDto userDto)
        {
            var validator = new UserValidator();
            var resultValidator = validator.Validate(userDto);

            if (!resultValidator.IsValid)
            {
                throw new ValidationException(resultValidator.Errors);
            }

            var user = await _userRepository.GetByUsernameAsync(userDto.Username);

            if (user == null || !VerifyPasswordHash(userDto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            var token = _tokenService.GenerateToken(user);

            return token;
        }

        private bool VerifyPasswordHash(string password, string passwordHash)
        {
            var secretKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
