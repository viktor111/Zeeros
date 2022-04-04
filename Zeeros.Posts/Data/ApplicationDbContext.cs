using Microsoft.EntityFrameworkCore;
using Zeeros.Posts.Models;

namespace Zeeros.Posts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
