using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKMSmalta.Dialogs.Factories;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class RegisterDialogViewModel : LoginDialogViewModel
    {
        private readonly DialogFactory dialogFactory;

        public SecureString ConfirmPassword => PasswordSupplier.GetConfirmPassword();

        public RegisterDialogViewModel(IPasswordSupplier passwordSupplier, string registerUri, DialogFactory dialogFactory) : base(passwordSupplier, registerUri)
        {
            this.dialogFactory = dialogFactory;
        }

        protected override async Task OnClick()
        {
            var password = Password.ConvertToUnsecureString();
            var confirmPassword = ConfirmPassword.ConvertToUnsecureString();

            if (password != confirmPassword)
            {
                throw new Exception("Пароль и его подтверждение должны совпадать");
            }

            using (var httpClient = new HttpClient())
            {
                var registerCredentials = new RegisterCredentials(Login, password, confirmPassword);
                var json = JsonConvert.SerializeObject(registerCredentials);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(RequestUri, body);
                if (response.IsSuccessStatusCode)
                {
                    CloseCommand.Execute(null);
                    dialogFactory.ShowLoginDialog();
                }
                else
                {
                    throw new Exception("Неопознанная ошибка на сервере, пожалуйста, обратитесь к разработчику");
                }
            }
        }
    }
}