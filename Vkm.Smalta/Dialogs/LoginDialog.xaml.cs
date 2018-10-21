#region Usings

using System.Security;
using Vkm.ComplexSim.Dialogs.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : IPasswordSupplier
    {
        public LoginDialog()
        {
            InitializeComponent();
            DataContext = new LoginDialogViewModel(this);
            Initialize();
        }

        #region IPasswordSupplier

        public SecureString GetConfirmPassword()
        {
            return null;
        }

        public SecureString GetPassword()
        {
            return PasswordBox.SecurePassword;
        }

        #endregion
    }
}