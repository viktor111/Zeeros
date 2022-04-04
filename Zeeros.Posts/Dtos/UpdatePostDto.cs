namespace Zeeros.Posts.Dtos
{
    public class UpdatePostDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public string Content { get; set; } = String.Empty;

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
