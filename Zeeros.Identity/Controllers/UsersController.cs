using Microsoft.AspNetCore.Mvc;
using Zeeros.Identity.Data.Repositories;
using Zeeros.Identity.Dtos;
using Zeeros.Identity.Models;
using Zeeros.Identity.Service;

namespace Zeeros.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;
        private readonly IConfiguration _configuration;
        private readonly IRegisterService _registerService;

        public UsersController(IUserRepository userRepository,
            ITokenService tokenService,
            IPasswordService passwordService,
            IConfiguration configuration,
            IRegisterService registerService)
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
            _configuration = configuration;
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateUserDto authenticateUserDto)
        {
            var user = await _userRepository.GetUserByUsername(authenticateUserDto.UserName);

            if (user is not null)
            {
                bool res = _passwordService.Verify(authenticateUserDto.Password, user.PasswordHash);
                if (res)
                {
                    var jwt = _tokenService.Issue(user, _configuration);
                    return Ok(jwt);
                }
            }

            return NotFound("Incorrect phone number or password");
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterUserDto registerUserDto)
        {
            var createdUser = await _registerService.RegisterNewUser(registerUserDto);
            string passwordHash = _passwordService.Hash(registerUserDto.Password);
            var user = new User 
            { 
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,
                PasswordHash = passwordHash 
            };
            await _userRepository.CreateUser(user);
            await _userRepository.SaveChanges();
            var createdUser = _userRepository.GetUserById(user.Id);

            return Ok(createdUser);
        }
    }
}
