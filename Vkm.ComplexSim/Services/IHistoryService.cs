#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.Services
{
    public interface IHistoryService
    {
        List<Action> Actions { get; }

        int GetValueByAlgorithmByEndStateOfElements(Algorithm algorithm, List<ElementViewModelBase> elements);
        int GetValueByAlgorithmByUserActions(Algorithm algorithm, List<ElementViewModelBase> elements);
        void Reset();
    }
}