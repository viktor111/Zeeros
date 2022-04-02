namespace Zeeros.Identity.Service
{
    public interface IPasswordService
    {
        public string Hash(string password, int workFactor = 11);
        public bool Verify(string password, string hash);
    }
}
