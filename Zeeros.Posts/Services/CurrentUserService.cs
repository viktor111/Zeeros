using System.Security.Claims;

namespace Zeeros.Posts.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = int.Parse(this.user.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public int UserId { get; }

        public bool IsAdministrator => this.user.IsInRole("Admin");
    }
}
