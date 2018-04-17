using System;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.XtraEditors;
using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.Factories
{
    public class DialogFactory
    {
        public void ShowLoginDialog()
        {
            var authUri = DependencyContainer.Instance.Config.AdminUri.AdminAuthorizeUri;
            var loginDialog = new LoginDialog(authUri);
            loginDialog.ShowDialog();
        }

        public void ShowRegisterDialog()
        {
            var registerUri = DependencyContainer.Instance.Config.AdminUri.AdminRegisterUri;
            var registerDialog = new RegisterDialog(registerUri, this);
            registerDialog.ShowDialog();
        }

        public void ShowInfoDialog(string infoText)
        {
            var infoDialog = new InfoDialog(infoText);
            infoDialog.ShowDialog();
        }

        public static void ShowWarningMessage(string text, string caption = null)
        {
            DXMessageBox.Show(text, caption ?? "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowErrorMessage(Exception error, string caption = null)
        {
            DXMessageBox.Show(error.Message, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowErrorMessage(string error, string caption = null)
        {
            DXMessageBox.Show(error, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowInfoMessage(string text, string caption = null)
        {
            DXMessageBox.Show(text, caption ?? "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}