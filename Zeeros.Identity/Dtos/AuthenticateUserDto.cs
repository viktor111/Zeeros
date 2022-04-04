namespace Zeeros.Identity.Dtos
{
    public class AuthenticateUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
