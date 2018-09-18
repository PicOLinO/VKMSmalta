using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

namespace Vkm.Smalta.Services
{
    public interface IHistoryService
    {
        List<Action> Actions { get; }

        int GetValueByAlgorithmByEndStateOfElements(Algorithm algorithm, List<IValuableNamedElement> elements);
        int GetValueByAlgorithmByUserActions(Algorithm algorithm, List<IValuableNamedElement> elements);
        void Reset();
    }
}