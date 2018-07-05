using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;
using Action = System.Action;

namespace Vkm.Smalta.Tests.Fakes.ServicesAndFactories
{
    public class HintServiceStub : IHintService
    {
        public InnerRegionPage PageNavigatedOn { get; private set; }
        public bool TrainingStarted { get; private set; }
        public bool NextHintIsShown { get; private set;}
        public bool ResetWasRaised { get; private set; }

        public IValuableNamedElement GetValuableElementByCurrentHint()
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigated(InnerRegionPage toPage)
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
    }
}