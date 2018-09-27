#region Usings

using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IDialogFactory
    {
        bool AskYesNo(string text, string caption = null);
        Algorithm ShowChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms);
        DeviceEntry ShowChooseDeviceDialog(IDevicesFactory devicesFactory);
        void ShowErrorMessage(Exception error, string caption = null);
        void ShowErrorMessage(string error, string caption = null);
        bool ShowExamineResultDialog(int value);
        void ShowInfoDialog();
        void ShowInfoMessage(string text, string caption = null);
        bool ShowLoginDialog();
        bool ShowRegisterDialog();
        TrainingCompleteDialogResult ShowTrainingCompleteDialog();
        void ShowWarningMessage(string text, string caption = null);
    }
}