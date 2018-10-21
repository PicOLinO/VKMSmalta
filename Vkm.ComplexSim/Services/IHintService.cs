#region Usings

using System;
using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Action = System.Action;

#endregion

namespace Vkm.ComplexSim.Services
{
    public interface IHintService
    {
        ElementViewModelBase GetElementByCurrentHint();
        void OnNavigated(Enum toPage);
        void Reset();
        void ShowNextHint();
        void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, Action endTraining);
    }
}