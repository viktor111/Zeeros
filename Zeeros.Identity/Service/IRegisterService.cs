using Zeeros.Identity.Dtos;
using Zeeros.Identity.Models;

namespace Zeeros.Identity.Service
{
    public interface IRegisterService
    {
        Task<User> RegisterNewUser(RegisterUserDto registerUserDto);
    }
}
