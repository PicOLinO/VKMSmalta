using System;
using System.Windows;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors.Helpers;
using DevExpress.XtraEditors;
using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.Factories
{
    public class DialogFactory
    {
        public bool ShowLoginDialog()
        {
            var loginDialog = new LoginDialog();
            var result = loginDialog.ShowDialog();
            return result.HasValue && result.Value;
        }

        public bool ShowRegisterDialog()
        {
            var registerDialog = new RegisterDialog();
            var result = registerDialog.ShowDialog();
            return result.HasValue && result.Value;
        }

        public void ShowInfoDialog()
        {
            var infoDialog = new InfoDialog();
            infoDialog.ShowDialog();
        }

        public static void ShowWarningMessage(string text, string caption = null)
        {
            DXMessageBox.Show(text, caption ?? "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowErrorMessage(Exception error, string caption = null)
        {
            var msg = error.Message;
            if (!string.IsNullOrEmpty(error.InnerException?.Message))
                msg += "\r\n" + error.InnerException?.Message;
            DXMessageBox.Show(msg, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowErrorMessage(string error, string caption = null)
        {
            DXMessageBox.Show(error, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowInfoMessage(string text, string caption = null)
        {
            DXMessageBox.Show(text, caption ?? "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static bool AskYesNo(string text, string caption = null)
        {
            var result = DXMessageBox.Show(text, caption ?? "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}