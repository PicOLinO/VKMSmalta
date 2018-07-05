#region Usings

using System.Net;
using System.Security;
using System.Security.Authentication;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class LoginDialogViewModel : DialogViewModelBase
    {
        protected readonly IPasswordSupplier PasswordSupplier;

        public LoginDialogViewModel(IPasswordSupplier passwordSupplier)
        {
            PasswordSupplier = passwordSupplier;
            CreateCommands();
        }

        public DelegateCommand ClickCommand { get; set; }

        public string Login
        {
            get { return GetProperty(() => Login); }
            set { SetProperty(() => Login, value); }
        }

        protected SecureString Password => PasswordSupplier.GetPassword();
        private AppGlobal App => DependencyContainer.GetApp();

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
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

        protected virtual void OnClick()
        {
            Task.Run(OnClickCore).Wait();
            if (App.IsAuthorized)
            {
                CloseCommand.Execute(true);
            }
        }
    }
}