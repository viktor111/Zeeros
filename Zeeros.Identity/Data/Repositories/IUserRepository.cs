using Zeeros.Identity.Models;

namespace Zeeros.Identity.Data.Repositories
{
    public interface IUserRepository
    {
        public bool SaveChanges();

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task<User> CreateUser(User user);
    }
}
