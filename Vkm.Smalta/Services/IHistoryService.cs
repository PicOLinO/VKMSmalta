#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace Vkm.Smalta.Services
{
    public interface IHistoryService
    {
        List<Action> Actions { get; }

        int GetValueByAlgorithmByEndStateOfElements(Algorithm algorithm, List<ElementViewModelBase> elements);
        int GetValueByAlgorithmByUserActions(Algorithm algorithm, List<ElementViewModelBase> elements);
        void Reset();
    }
}