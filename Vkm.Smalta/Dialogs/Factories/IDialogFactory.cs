using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

namespace Vkm.Smalta.Dialogs.Factories
{
    public interface IDialogFactory
    {
        void ShowInfoDialog();
        bool ShowLoginDialog();
        bool ShowRegisterDialog();
        Algorithm ShowChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms);
        DeviceEntry ShowChooseDeviceDialog(DevicesFactory devicesFactory);
        TrainingCompleteDialogResult ShowTrainingCompleteDialog();
    }
}