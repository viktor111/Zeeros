using Microsoft.EntityFrameworkCore;
using Zeeros.Identity.Models;

namespace Zeeros.Identity.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _dbContext;

        public UserRepository(IdentityDbContext context)
        {
            _dbContext = context;
        }

        public async Task<User> CreateUser(User user)
        {
            var result = await _dbContext.Users.AddAsync(user);

            return result.Entity;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = await _dbContext.Users.ToListAsync();

            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(result is null)
            {
                return new User();
            }

            return result;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (result is null)
            {
                return new User();
            }

            return result;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var result = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (result is null)
            {
                return new User();
            }

            return result;
        }
    }
}
