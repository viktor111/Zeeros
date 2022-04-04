using Microsoft.AspNetCore.Mvc;
using Zeeros.Posts.Data.Repositories;
using Zeeros.Posts.Dtos;
using Zeeros.Posts.Models;
using Zeeros.Posts.Services;

namespace Zeeros.Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly ICurrentUserService _currentUser;

        public PostsController(
            IPostRepository postRepository,
            ICurrentUserService currentUser)
        {
            _postRepository = postRepository;
            _currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePostDto createPostDto)
        {
            var user = _currentUser.UserId;

            var post = new Post() 
            { 
                Content = createPostDto.Content, 
                Title = createPostDto.Title,
                CreatedDate = DateTime.Now,
                UserId = createPostDto.UserId 
            };

            await _postRepository.CreatePost(post);

            var result = await _postRepository.SaveChanges();

            if(!result)
            {
                return BadRequest("Post could not be created");
            }

            return Ok("Post created");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DeletePostDto deletePostDto)
        {
            var user = _currentUser.UserId;

            if(deletePostDto.UserId != user)
            {
                return BadRequest("Not logged in");
            }

            var post = await _postRepository.GetPostById(deletePostDto.Id);

            _postRepository.DeletePost(post);

            await _postRepository.SaveChanges();

            return Ok("Post deleted");
        }

        [HttpGet]
        public async Task<ActionResult> GetPosts(int id)
        {
            var posts = await _postRepository.GetPostsForUser(id);

            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UpdatePostDto updatePostDto)
        {
            var post = new Post() 
            { 
                Content = updatePostDto.Content,
                Id = updatePostDto.Id,
                CreatedDate = updatePostDto.CreatedDate,
                Title = updatePostDto.Title,
                UserId = updatePostDto.UserId
            };

            _postRepository.UpdatePost(post);
            await _postRepository.SaveChanges();

            return Ok("Post updated");
        }
    }
}
