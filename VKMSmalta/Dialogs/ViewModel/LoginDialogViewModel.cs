using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Newtonsoft.Json;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class LoginDialogViewModel : DialogViewModelBase
    {
        protected readonly IPasswordSupplier PasswordSupplier;
        protected readonly string RequestUri;

        public string Login
        {
            get { return GetProperty(() => Login); }
            set { SetProperty(() => Login, value); }
        }

        public SecureString Password => PasswordSupplier.GetPassword();

        public AsyncCommand ClickCommand { get; set; }

        public LoginDialogViewModel(IPasswordSupplier passwordSupplier, string authUri)
        {
            PasswordSupplier = passwordSupplier;
            RequestUri = authUri;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new AsyncCommand(OnClick);
        }

        protected virtual async Task OnClick()
        {
            using (var httpClient = new HttpClient())
            {
                var credentials = new NetworkCredential(Login, Password);
                var json = JsonConvert.SerializeObject(credentials);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(RequestUri, body);
                if (response.IsSuccessStatusCode)
                {
                    //TODO: Логин успешен, сохранить токен.
                }
                else
                {
                    throw new AuthenticationException("Неверный логин или пароль");
                }
            }
        }
    }
}