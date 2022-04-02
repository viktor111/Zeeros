namespace Zeeros.Identity.Service
{
    public class PasswordService : IPasswordService
    {
        public string Hash(string password, int workFactor)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, workFactor);
        }

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
    }
}
