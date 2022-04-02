using Zeeros.Identity.Models;

namespace Zeeros.Identity.Service
{
    public interface ITokenService
    {
        public string Issue(User user, IConfiguration configuration);
    }
}
