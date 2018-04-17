using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class RegisterDialogViewModel : LoginDialogViewModel
    {
        public SecureString ConfirmPassword => PasswordSupplier.GetConfirmPassword();

        public RegisterDialogViewModel(IPasswordSupplier passwordSupplier, string registerUri) : base(passwordSupplier, registerUri)
        {
        }

        protected override async Task OnClick()
        {
            if (Password != ConfirmPassword)
            {
                throw new Exception("Пароль и его подтверждение должны совпадать");
            }

            using (var httpClient = new HttpClient())
            {
                var registerCredentials = new RegisterCredentials(Login, Password.ConvertToUnsecureString(), ConfirmPassword.ConvertToUnsecureString());
                var json = JsonConvert.SerializeObject(registerCredentials);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(RequestUri, body);
                if (response.IsSuccessStatusCode)
                {
                    //TODO: Регистрация успешна.
                }
                else
                {
                    throw new AuthenticationException("Неверный логин или пароль");
                }
            }
        }
    }
}