using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.Elements.ViewModel.Interfaces;
using Action = System.Action;

namespace VKMSmalta.Services
{
    public interface IHintService
    {
        IValuableNamedElement GetValuableElementByCurrentHint();
        void OnNavigated(InnerRegionPage toPage);
        void Reset();
        void ShowNextHint();
        void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, Action endTraining);
    }
}