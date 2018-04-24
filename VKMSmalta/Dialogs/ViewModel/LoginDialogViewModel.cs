using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Newtonsoft.Json;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class LoginDialogViewModel : DialogViewModelBase
    {
        protected readonly IPasswordSupplier PasswordSupplier;
        protected AppGlobal App => DependencyContainer.GetApp();

        public string Login
        {
            get { return GetProperty(() => Login); }
            set { SetProperty(() => Login, value); }
        }

        public SecureString Password => PasswordSupplier.GetPassword();

        public DelegateCommand ClickCommand { get; set; }

        public LoginDialogViewModel(IPasswordSupplier passwordSupplier)
        {
            PasswordSupplier = passwordSupplier;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        protected virtual void OnClick()
        {
            Task.Run(OnClickCore).Wait();
            if (App.IsAuthorized)
            {
                CloseCommand.Execute(true);
            }
        }

        private async Task OnClickCore()
        {
            var credentials = new NetworkCredential(Login, Password);
            var student = await NetworkService.Instance.Authorize(credentials);

            if (student != null)
            {
                App.IsAuthorized = true;
                App.CurrentUser = student;
            }
            else
            {
                throw new AuthenticationException("Неверный логин или пароль");
            }
        }
    }
}