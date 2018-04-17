using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Newtonsoft.Json;
using VKMSmalta.Services;

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
            var credentials = new NetworkCredential(Login, Password);
            var success = await NetworkService.Instance.Authorize(credentials);

            if (success)
            {
                //TODO: Показать пользователю, что он авторизован.
            }

            throw new AuthenticationException("Неверный логин или пароль");
        }
    }
}