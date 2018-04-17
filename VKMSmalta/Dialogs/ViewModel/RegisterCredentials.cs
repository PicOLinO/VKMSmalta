using System.Net;
using System.Security;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class RegisterCredentials
    {
        public RegisterCredentials(string login, string password, string confirmPassword)
        {
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}