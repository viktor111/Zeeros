using Zeeros.Identity.Data.Repositories;
using Zeeros.Identity.Dtos;
using Zeeros.Identity.Models;

namespace Zeeros.Identity.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        public RegisterService(IPasswordService passwordService, IUserRepository userRepository)
        {
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        public async Task<User> RegisterNewUser(RegisterUserDto registerUserDto)
        {
            string passwordHash = _passwordService.Hash(registerUserDto.Password);
            var user = new User
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                PasswordHash = passwordHash
            };
            await _userRepository.CreateUser(user);
            await _userRepository.SaveChanges();
            var createdUser = await _userRepository.GetUserById(user.Id);

            return createdUser;
        }
    }
}
