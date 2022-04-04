using Zeeros.Posts.Models;

namespace Zeeros.Posts.Data.Repositories
{
    public interface IPostRepository
    {
        public Task<Post> CreatePost(Post post);

        public Post UpdatePost(Post post);

        public void DeletePost(Post post);

        public Task<Post> GetPostById(int id);

        public Task<IEnumerable<Post>> GetPostsForUser(int userId);

        public Task<bool> SaveChanges();
    }
}
