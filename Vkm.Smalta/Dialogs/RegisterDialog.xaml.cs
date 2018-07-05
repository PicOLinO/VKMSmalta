#region Usings

using System.Security;
using Vkm.Smalta.Dialogs.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class RegisterDialog : IPasswordSupplier
    {
        public RegisterDialog()
        {
            InitializeComponent();
            DataContext = new RegisterDialogViewModel(this);
            Initialize();
        }

        #region IPasswordSupplier

        public SecureString GetConfirmPassword()
        {
            return ConfirmPasswordBox.SecurePassword;
        }

        public SecureString GetPassword()
        {
            return PasswordBox.SecurePassword;
        }

        #endregion
    }
}