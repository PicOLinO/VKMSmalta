#region Usings

using System.Collections.Generic;
using System.Linq;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;
using Action = System.Action;

#endregion

namespace Vkm.Smalta.Services
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

        public IValuableNamedElement GetValuableElementByCurrentHint()
        {
            if (CurrentAction != null)
            {
                return Elements.Cast<IValuableNamedElement>().Single(e => e.Name == CurrentAction?.ParentElementName);
            }

            return null;
        }

        public void OnNavigated(InnerRegionPage toPage)
        {
            if (CurrentAction == null)
            {
                return;
            }

            var currentHintedElement = Elements.Single(e => e.Name == CurrentAction?.ParentElementName);

            CurrentDevicePageService.Instance.ShowGoNextPageHint(currentHintedElement.Page, currentHintedElement.Page == toPage);
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

            var page = CurrentDevicePageService.Instance.GetCurrentInnerPageKey();
            if (page != element.Page)
            {
                CurrentDevicePageService.Instance.ShowGoNextPageHint(element.Page);
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
    }
}