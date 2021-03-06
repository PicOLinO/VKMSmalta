﻿#region Usings

using System;
using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Action = System.Action;

#endregion

namespace Vkm.ComplexSim.Tests.Fakes.ServicesAndFactories
{
    public class HintServiceStub : IHintService
    {
        public bool NextHintIsShown { get; private set; }
        public Enum PageNavigatedOn { get; private set; }
        public bool ResetWasRaised { get; private set; }
        public bool TrainingStarted { get; private set; }

        #region IHintService

        public ElementViewModelBase GetElementByCurrentHint()
        {
            throw new NotImplementedException();
        }

        public void OnNavigated(Enum toPage)
        {
            PageNavigatedOn = toPage;
        }

        public void Reset()
        {
            ResetWasRaised = true;
        }

        public void ShowNextHint()
        {
            NextHintIsShown = true;
        }

        public void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, Action endTraining)
        {
            TrainingStarted = true;
        }

        #endregion
    }
}