#region Usings

using System;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

#endregion

namespace VKMSmalta.Dialogs.Factories
{
    public class DialogFactory
    {
        private static readonly IMessageBoxService Service = new MessageBoxService();

        public static bool AskYesNo(string text, string caption = null)
        {
            var result = Service.Show(text, caption ?? "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public static void ShowErrorMessage(Exception error, string caption = null)
        {
            var msg = error.Message;
            if (!string.IsNullOrEmpty(error.InnerException?.Message))
            {
                msg += "\r\n" + error.InnerException?.Message;
            }

            Service.Show(msg, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowErrorMessage(string error, string caption = null)
        {
            Service.Show(error, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowInfoMessage(string text, string caption = null)
        {
            Service.Show(text, caption ?? "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowWarningMessage(string text, string caption = null)
        {
            Service.Show(text, caption ?? "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowInfoDialog()
        {
            var infoDialog = new InfoDialog();
            infoDialog.ShowDialog();
        }

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
    }
}