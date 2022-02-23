namespace CoreBL
{
    public interface IAuthService
    {
        string CreateAuthToken(string login);
    }
}