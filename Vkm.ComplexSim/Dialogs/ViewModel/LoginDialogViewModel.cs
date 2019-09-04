#region Usings

using System;
using System.Net;
using System.Security;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Services;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public class LoginDialogViewModel : DialogViewModelBase
    {
        protected readonly IDialogFactory DialogFactory;
        protected readonly IPasswordSupplier PasswordSupplier;

        public LoginDialogViewModel(IDialogFactory dialogFactory, IPasswordSupplier passwordSupplier)
        {
            DialogFactory = dialogFactory;
            PasswordSupplier = passwordSupplier;
            CreateCommands();
        }

        public ICommand ClickCommand { get; set; }

        public string Login
        {
            get { return GetProperty(() => Login); }
            set { SetProperty(() => Login, value); }
        }

        protected SecureString Password => PasswordSupplier.GetPassword();
        private IAppContext App => DependencyContainer.GetApp();

        private void CreateCommands()
        {
            ClickCommand = new AsyncCommand(OnClickOk, CanLogin);
        }

        private bool CanLogin()
        {
            return Password.Length > 0 && !string.IsNullOrWhiteSpace(Login);
        }

        private async Task Authorize()
        {
            var networkService = GetService<INetworkService>();

            var credentials = new NetworkCredential(Login, Password);
            var student = await networkService.Authorize(credentials);

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

        protected virtual async Task OnClickOk()
        {
            try
            {
                await Authorize();
                if (App.IsAuthorized)
                {
                    CloseCommand.Execute(true);
                }
            }
            catch (Exception e)
            {
                DialogFactory.ShowErrorMessage(e);
            }
        }
    }
}