using System;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Services;

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
                DialogFactory.ShowWarningMessage("Пароли должны совпадать");
                return;
            }

            var success = await NetworkService.Instance.Register(new NetworkCredential(Login, Password));

            if (success)
            {
                CloseCommand.Execute(null);
                dialogFactory.ShowLoginDialog();
            }

            DialogFactory.ShowErrorMessage("Ошибка на сервере, обратитесь к преподавателю");
        }
    }
}