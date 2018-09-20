using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IDialogFactory
    {
        bool AskYesNo(string text, string caption = null);
        void ShowErrorMessage(Exception error, string caption = null);
        void ShowErrorMessage(string error, string caption = null);
        void ShowInfoMessage(string text, string caption = null);
        void ShowWarningMessage(string text, string caption = null);
        void ShowInfoDialog();
        bool ShowLoginDialog();
        bool ShowRegisterDialog();
        Algorithm ShowChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms);
        DeviceEntry ShowChooseDeviceDialog(IDevicesFactory devicesFactory);
        TrainingCompleteDialogResult ShowTrainingCompleteDialog();
    }
}