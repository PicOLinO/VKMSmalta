using System;
using System.Security;
using DevExpress.Mvvm;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class LoginDialogViewModel : ViewModelBase
    {
        private readonly IPasswordSupplier passwordSupplier;

        public string Login
        {
            get { return GetProperty(() => Login); }
            set { SetProperty(() => Login, value); }
        }

        public SecureString Password
        {
            get { return GetProperty(() => passwordSupplier.GetPassword()); }
        }

        public DelegateCommand ClickCommand { get; set; }

        public LoginDialogViewModel(IPasswordSupplier passwordSupplier)
        {
            this.passwordSupplier = passwordSupplier;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        private void OnClick()
        {
            throw new NotImplementedException();
        }
    }
}