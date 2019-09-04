#region Usings

using System.Security;
using System.Windows;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Dialogs.ViewModel;
using Vkm.ComplexSim.Services;

#endregion

namespace Vkm.ComplexSim.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : IPasswordSupplier
    {
        public LoginDialog(IDialogFactory dialogFactory)
        {
            InitializeComponent();
            DataContext = new LoginDialogViewModel(dialogFactory, this);
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