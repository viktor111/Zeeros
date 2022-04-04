namespace Zeeros.Posts.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAdministrator { get; }
    }
}
