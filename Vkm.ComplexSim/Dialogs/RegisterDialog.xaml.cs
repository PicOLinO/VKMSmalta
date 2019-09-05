#region Usings

using System.Security;
using System.Threading.Tasks;
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
    public partial class RegisterDialog : IPasswordSupplier
    {
        public RegisterDialog(IDialogFactory dialogFactory)
        {
            InitializeComponent();
            DataContext = new RegisterDialogViewModel(dialogFactory, this);
        }

        public new async Task Initialize()
        {
            await ((RegisterDialogViewModel) DataContext).LoadTeamsWithStudentsWithoutLogins();
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