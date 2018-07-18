#region Usings

using System.Collections.Generic;
using System.Linq;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;

#endregion

namespace Vkm.Smalta.Services
{
    public class HistoryService
    {
        public HistoryService()
        {
            Actions = new List<Action>();
        }

        public List<Action> Actions { get; }

        public int GetValueByAlgorithmByEndStateOfElements(Algorithm algorithm, List<IValuableNamedElement> elements)
        {
            var rightsCount = 0;
            var allCount = 0;

            foreach (var algorithmEndStateOfElement in algorithm.EndStateOfElements)
            {
                allCount++;
                if (elements.Single(el => el.Name == algorithmEndStateOfElement.Key).Value == algorithmEndStateOfElement.Value)
                {
                    rightsCount++;
                }
            }

            if (allCount == 0)
            {
                return -1;
            }

            var value = rightsCount * 5 / allCount;

            return value <= 0
                       ? 1
                       : value;
        }

        public int GetValueByAlgorithmByUserActions(Algorithm algorithm, List<IValuableNamedElement> elements)
        {
            //TODO: Несовершенно. Много ошибок. Надо превращать фабрику по производству алгоритмов в DSL и добавлять зависимости.
            var allCount = algorithm.Actions.Count;
            var rightsCount = 0;

            var previousActionIndex = 0;

            foreach (var algorithmAction in algorithm.Actions)
            {
                foreach (var action in Actions)
                {
                    if (algorithmAction.Name == action.Name && algorithmAction.ParentElementName == action.ParentElementName)
                    {
                        var indexOfAction = Actions.IndexOf(action);
                        if (indexOfAction >= previousActionIndex)
                        {
                            rightsCount++;
                            previousActionIndex = indexOfAction;
                            break;
                        }
                    }
                }
            }

            if (allCount == 0)
            {
                return -1;
            }

            var value = rightsCount * 5 / allCount;

            return value <= 0
                       ? 1
                       : value;
        }

        public void Reset()
        {
            Actions.Clear();
        }
    }
}