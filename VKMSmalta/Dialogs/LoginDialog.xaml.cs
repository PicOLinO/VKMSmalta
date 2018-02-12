using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VKMSmalta.Dialogs.ViewModel;

namespace VKMSmalta.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window, IPasswordSupplier
    {
        public LoginDialog()
        {
            InitializeComponent();
            DataContext = new LoginDialogViewModel(this);
        }

        public SecureString GetPassword()
        {
            return passwordBox.SecurePassword;
        }
    }
}
