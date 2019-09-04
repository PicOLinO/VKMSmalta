#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Tests.Fakes.ServicesAndFactories
{
    public class DialogFactoryStub : IDialogFactory
    {
        public bool BoolDialogResult { get; set; }
        public bool IsAskYesNoDialogShown { get; private set; }
        public bool IsChooseAlgorithmDialogShown { get; private set; }
        public bool IsChooseDeviceDialogShown { get; private set; }

        public bool IsExamineResultDialogShown { get; private set; }
        public bool IsInfoDialogShown { get; private set; }
        public bool IsLoginDialogShown { get; private set; }
        public bool IsRegisterDialogShown { get; private set; }

        public bool TrainingCompleteDialogShown { get; private set; }

        #region IDialogFactory

        public bool AskYesNo(string text, string caption = null)
        {
            IsAskYesNoDialogShown = true;
            return BoolDialogResult;
        }

        public Algorithm ShowChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms)
        {
            IsChooseAlgorithmDialogShown = true;
            return new Algorithm(new Dictionary<string, int>(), new Dictionary<string, int>());
        }

        public DeviceEntry ShowChooseDeviceDialog(IDevicesFactory devicesFactory)
        {
            IsChooseDeviceDialogShown = true;
            return new DeviceEntry();
        }

        public void ShowErrorMessage(Exception error, string caption = null)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string error, string caption = null)
        {
            throw new NotImplementedException();
        }

        public bool ShowExamineResultDialog(int value)
        {
            IsExamineResultDialogShown = true;
            return BoolDialogResult;
        }

        public void ShowInfoDialog()
        {
            IsInfoDialogShown = true;
        }

        public void ShowInfoMessage(string text, string caption = null)
        {
            throw new NotImplementedException();
        }

        public bool ShowLoginDialog()
        {
            IsLoginDialogShown = true;
            return true;
        }

        public Task<bool> ShowRegisterDialogAsync()
        {
            IsRegisterDialogShown = true;
            return Task.FromResult(true);
        }

        public TrainingCompleteDialogResult ShowTrainingCompleteDialog()
        {
            TrainingCompleteDialogShown = true;
            return new TrainingCompleteDialogResult
                   {
                       GoExamine = true
                   };
        }

        public void ShowWarningMessage(string text, string caption = null)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}