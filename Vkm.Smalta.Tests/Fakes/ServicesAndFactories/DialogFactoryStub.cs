﻿#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class DialogFactoryStub : IDialogFactory
    {
        public bool IsInfoDialogShown { get; private set; }
        public bool IsLoginDialogShown { get; private set; }
        public bool IsRegisterDialogShown { get; private set; }
        public bool IsChooseAlgorithmDialogShown { get; private set; }

        #region IDialogFactory

        public Algorithm ShowChooseAlgorithmDialog(IHintService hintService)
        {
            IsChooseAlgorithmDialogShown = true;
            return new Algorithm(new Dictionary<string, int>(), new Dictionary<string, int>());
        }

        public bool ShowTrainingCompleteDialog()
        {
            TrainingCompleteDialogShown = true;
            return true;
        }

        public bool TrainingCompleteDialogShown { get; private set; }

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