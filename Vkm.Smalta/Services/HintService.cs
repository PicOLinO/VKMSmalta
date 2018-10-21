#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Vkm.ComplexSim.View.ViewModel;
using Action = System.Action;

#endregion

namespace Vkm.ComplexSim.Services
{
    public class HintService : IHintService
    {
        private Algorithm Algorithm { get; set; }
        private Action Callback { get; set; }
        private Domain.Action CurrentAction { get; set; }
        private List<ElementViewModelBase> Elements { get; set; }

        private void HideCurrentHint()
        {
            var element = Elements.Single(e => e.Name == CurrentAction?.ParentElementName);

            element.IsEnabled = false;
            element.IsHintOpen = false;

            CurrentAction = null;
        }

        #region IHintService

        public ElementViewModelBase GetElementByCurrentHint()
        {
            if (CurrentAction != null)
            {
                return Elements.Single(e => e.Name == CurrentAction?.ParentElementName);
            }

            return null;
        }

        public void OnNavigated(Enum toPage)
        {
            if (CurrentAction == null)
            {
                return;
            }

            var currentHintedElement = Elements.Single(e => e.Name == CurrentAction?.ParentElementName);

            DevicePageViewModel.Instance.ShowGoNextPageHint(currentHintedElement.Page, currentHintedElement.Page == toPage);
        }

        public void Reset()
        {
            CurrentAction = null;
        }

        public void ShowNextHint()
        {
            Domain.Action action;
            if (CurrentAction == null)
            {
                action = Algorithm.Actions.FirstOrDefault();
            }
            else
            {
                action = Algorithm.Actions.Find(CurrentAction)?.Next?.Value;
                HideCurrentHint();
            }

            if (action == null)
            {
                Callback();
                return;
            }

            var element = Elements.Single(e => e.Name == action?.ParentElementName);

            var page = DevicePageViewModel.Instance.GetCurrentInnerPageKey();
            if (!Equals(page, element.Page))
            {
                DevicePageViewModel.Instance.ShowGoNextPageHint(element.Page);
            }

            element.IsEnabled = true;
            element.Hint = action.Hint;
            element.IsHintOpen = true;

            CurrentAction = action;
        }

        public void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, Action endTraining)
        {
            Elements = elements;
            Algorithm = algorithm;
            Callback = endTraining;

            ShowNextHint();
        }

        #endregion
    }
}