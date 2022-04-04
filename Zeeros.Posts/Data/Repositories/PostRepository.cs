using Microsoft.EntityFrameworkCore;
using Zeeros.Posts.Models;

namespace Zeeros.Posts.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var createdPost = await _dbContext.Posts.AddAsync(post);

            return createdPost.Entity;
        }

        public void DeletePost(Post post)
        {
            _dbContext.Posts.Remove(post);
        }

        public async Task<Post> GetPostById(int id)
        {
            var post = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if(post is null)
            {
                return new Post();
            }

            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsForUser(int userId)
        {
            var posts = await _dbContext.Posts
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return posts;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public Post UpdatePost(Post post)
        {
            _dbContext.Update(post);

            return post;
        }
    }
}
