#region Usings

using System;
using System.Collections.Generic;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class DialogFactoryStub : IDialogFactory
    {
        public bool BoolDialogResult { get; set; }

        public bool IsInfoDialogShown { get; private set; }
        public bool IsLoginDialogShown { get; private set; }
        public bool IsRegisterDialogShown { get; private set; }
        public bool IsChooseAlgorithmDialogShown { get; private set; }
        public bool IsChooseDeviceDialogShown { get; private set; }
        public bool IsAskYesNoDialogShown { get; private set; }

        #region IDialogFactory

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

        public TrainingCompleteDialogResult ShowTrainingCompleteDialog()
        {
            TrainingCompleteDialogShown = true;
            return new TrainingCompleteDialogResult
                   {
                       GoExamine = true
                   };
        }

        public bool TrainingCompleteDialogShown { get; private set; }

        public bool AskYesNo(string text, string caption = null)
        {
            IsAskYesNoDialogShown = true;
            return BoolDialogResult;
        }

        public void ShowErrorMessage(Exception error, string caption = null)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string error, string caption = null)
        {
            throw new NotImplementedException();
        }

        public void ShowInfoMessage(string text, string caption = null)
        {
            throw new NotImplementedException();
        }

        public void ShowWarningMessage(string text, string caption = null)
        {
            throw new NotImplementedException();
        }

        public void ShowInfoDialog()
        {
            IsInfoDialogShown = true;
        }

        public bool ShowLoginDialog()
        {
            IsLoginDialogShown = true;
            return true;
        }

        public bool ShowRegisterDialog()
        {
            IsRegisterDialogShown = true;
            return true;
        }

        #endregion
    }
}