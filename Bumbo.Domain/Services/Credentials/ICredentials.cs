using System.Threading.Tasks;

namespace Bumbo.Domain.Services.Credentials
{
    public interface ICredentials
    {
        Task<bool> Login(string Email, string Password);
        Task<string> PasswordForgot(string Email);
        bool sendEmailPasswordForgot(string Email, string resetUrl);
        Task<bool> setNewPassword(string Email, string Password);
        Task<bool> verifieerEmail(string Email, string token);
        void Logout();
    }
}
