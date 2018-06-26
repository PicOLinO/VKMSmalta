using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.Elements.ViewModel.Interfaces;
using Action = System.Action;

namespace VKMSmalta.Tests.Fakes.ServicesAndFactories
{
    public class HintServiceStub : IHintService
    {
        public IValuableNamedElement GetValuableElementByCurrentHint()
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigated(InnerRegionPage toPage)
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void ShowNextHint()
        {
            throw new System.NotImplementedException();
        }

        public void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, Action endTraining)
        {
            throw new System.NotImplementedException();
        }
    }
}