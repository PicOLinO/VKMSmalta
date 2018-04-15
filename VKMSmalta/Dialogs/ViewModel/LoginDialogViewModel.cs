using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Newtonsoft.Json;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class LoginDialogViewModel : DialogViewModelBase
    {
        private readonly IPasswordSupplier passwordSupplier;
        private readonly string authorizeUri;

        public string Login
        {
            get { return GetProperty(() => Login); }
            set { SetProperty(() => Login, value); }
        }

        public SecureString Password
        {
            get { return GetProperty(() => passwordSupplier.GetPassword()); }
        }

        public AsyncCommand ClickCommand { get; set; }

        public LoginDialogViewModel(IPasswordSupplier passwordSupplier, string authorizeUri)
        {
            this.passwordSupplier = passwordSupplier;
            this.authorizeUri = authorizeUri;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new AsyncCommand(OnClick);
        }

        private async Task OnClick()
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new { Login = Login, Password = Password });
                var body = new StringContent(json);
                var response = await httpClient.PostAsync(authorizeUri, body);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //TODO: Логин успешен
                }
                else
                {
                    throw new AuthenticationException("Неверный логин или пароль");
                }
            }
        }
    }
}