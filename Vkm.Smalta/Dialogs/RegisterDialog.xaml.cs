#region Usings

using System.Security;
using Vkm.ComplexSim.Dialogs.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs
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