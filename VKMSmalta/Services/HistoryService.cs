using System;
using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Domain;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.Elements.ViewModel.Interfaces;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Services
{
    public class HistoryService
    {
        public List<Action> Actions { get; }

        public HistoryService()
        {
            Actions = new List<Action>();
        }

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

            return value <= 0 ? 1 : value;
        }

        public int GetValueByAlgorithmByUserActions(Algorithm algorithm, List<IValuableNamedElement> elements)
        {
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
                        if (indexOfAction > previousActionIndex)
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

            return value <= 0 ? 1 : value;
        }

        public void Reset()
        {
            Actions.Clear();
        }
    }
}