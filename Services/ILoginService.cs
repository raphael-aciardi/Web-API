using Web_API.Models;

namespace Web_API.Services
{
    public interface ILoginService
    {
        Login Authenticate(string email, string password);
    }
}
