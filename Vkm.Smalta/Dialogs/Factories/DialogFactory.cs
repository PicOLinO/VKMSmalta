#region Usings

using System;
using System.Collections.Generic;
using System.Windows;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using Vkm.Smalta.Dialogs.ViewModel;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using MessageBoxService = DevExpress.Mvvm.UI.MessageBoxService;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public class DialogFactory : IDialogFactory
    {
        private readonly IMessageBoxService service;

        public DialogFactory(IMessageBoxService service)
        {
            this.service = service;
        }

        public bool AskYesNo(string text, string caption = null)
        {
            var result = service.Show(text, caption ?? "Вы уверены?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }

        public void ShowErrorMessage(Exception error, string caption = null)
        {
            var msg = error.Message;
            if (!string.IsNullOrEmpty(error.InnerException?.Message))
            {
                msg += "\r\n" + error.InnerException?.Message;
            }

            service.Show(msg, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowErrorMessage(string error, string caption = null)
        {
            service.Show(error, caption ?? "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInfoMessage(string text, string caption = null)
        {
            service.Show(text, caption ?? "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarningMessage(string text, string caption = null)
        {
            service.Show(text, caption ?? "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowInfoDialog()
        {
            using (var infoDialog = new InfoDialog())
            {
                infoDialog.Owner = Application.Current.MainWindow;
                infoDialog.ShowDialog();
            }
        }

        public bool ShowLoginDialog()
        {
            using (var loginDialog = new LoginDialog())
            {
                loginDialog.Owner = Application.Current.MainWindow;
                var result = loginDialog.ShowDialog();
                return result.HasValue && result.Value;
            }
        }

        public bool ShowRegisterDialog()
        {
            using (var registerDialog = new RegisterDialog())
            {
                registerDialog.Owner = Application.Current.MainWindow;
                var result = registerDialog.ShowDialog();
                return result.HasValue && result.Value;
            }
        }

        public bool ShowExamineResultDialog(int value)
        {
            using (var dialog = new CheckResultsDialog(value))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return ((CheckResultsDialogViewModel) dialog.DataContext).IsRetry;
            }
        }

        public Algorithm ShowChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms)
        {
            using (var dialog = new ChooseAlgorithmDialog(algorithms))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return dialog.SelectedAlgorithm;
            }
        }

        public DeviceEntry ShowChooseDeviceDialog(IDevicesFactory devicesFactory)
        {
            using (var dialog = new ChooseDeviceDialog(devicesFactory))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return dialog.SelectedDevice;
            }
        }

        public TrainingCompleteDialogResult ShowTrainingCompleteDialog()
        {
            using (var dialog = new TrainingCompleteDialog())
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return new TrainingCompleteDialogResult
                       {
                           GoExamine = dialog.GoExamine,
                           GoRetry = dialog.GoRetry
                       };
            }
        }
    }
}