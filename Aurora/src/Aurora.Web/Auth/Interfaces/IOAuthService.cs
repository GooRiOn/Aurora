namespace Aurora.Web.Auth.Interfaces
{
    public interface IOAuthService
    {
        string GetUserAuthToken(string userName, string userId, string[] roles);
    }
}