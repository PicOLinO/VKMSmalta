using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;
using Action = System.Action;

namespace Vkm.Smalta.Services
{
    public interface IHintService
    {
        IValuableNamedElement GetValuableElementByCurrentHint();
        void OnNavigated(SmaltaInnerRegionPage toPage);
        void Reset();
        void ShowNextHint();
        void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, Action endTraining);
    }
}