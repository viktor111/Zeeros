using Microsoft.EntityFrameworkCore;
using Zeeros.Identity.Models;

namespace Zeeros.Identity.Data
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
