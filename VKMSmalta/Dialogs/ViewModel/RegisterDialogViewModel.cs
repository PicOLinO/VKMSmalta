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
        public SecureString ConfirmPassword => PasswordSupplier.GetConfirmPassword();

        public RegisterDialogViewModel(IPasswordSupplier passwordSupplier) : base(passwordSupplier)
        {
        }

        protected override async Task OnClick()
        {
            try
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
                }
                else
                {
                    throw new Exception("Ошибка на сервере");
                }
            }
            catch (Exception e)
            {
                DialogFactory.ShowErrorMessage(e);
            }

        }
    }
}