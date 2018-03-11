using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Domain;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Services
{
    public class HintService
    {
        private List<ElementViewModelBase> Elements { get; set; }
        private Algorithm Algorithm { get; set; }
        private Action CurrentAction { get; set; }
        private System.Action Callback { get; set; }

        public void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements, System.Action endTraining)
        {
            Elements = elements;
            Algorithm = algorithm;
            Callback = endTraining;

            ShowNextHint();
        }

        public void ShowNextHint()
        {
            Action action;
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

            var page = DependencyContainer.Instance.GetCurrentInnerPage();
            if (page != element.Page)
            {
                DependencyContainer.Instance.ManageNavigateButtonHintForElement(element);
            }

            element.IsEnabled = true;
            element.Hint = action.Hint;
            element.IsHintOpen = true;

            CurrentAction = action;
        }

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

            DependencyContainer.Instance.ManageNavigateButtonHintForElement(currentHintedElement, currentHintedElement.Page == toPage);
        }

        public void Reset()
        {
            CurrentAction = null;
        }
    }
}