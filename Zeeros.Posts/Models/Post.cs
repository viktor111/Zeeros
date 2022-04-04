using System.ComponentModel.DataAnnotations;

namespace Zeeros.Posts.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = String.Empty;

        [Required]
        public string Content { get; set; } = String.Empty;

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
