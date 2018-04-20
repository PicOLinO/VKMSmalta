using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using VKMSmalta.Dialogs.ViewModel;

namespace VKMSmalta.Dialogs
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
            CreateCommands();
        }

        public SecureString GetPassword()
        {
            return passwordBox.SecurePassword;
        }

        public SecureString GetConfirmPassword()
        {
            return null;
        }
    }
}
