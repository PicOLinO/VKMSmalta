#region Usings

using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Hints.ViewModel;

#endregion

namespace VKMSmalta.Dialogs.Factories
{
    public class ActionsFactory
    {
        private readonly IHintService hintService;

        public ActionsFactory(IHintService hintService)
        {
            this.hintService = hintService;
        }

        public Action GetClickAction(string elementName, string hint, int accessibleValue)
        {
            return new Action(ActionName.Click, elementName, new AccessibleHintViewModel(hint, accessibleValue, hintService));
        }

        public Action GetIdleAction(string elementName, string hint, int accessibleValue)
        {
            return new Action(ActionName.Idle, elementName, new AccessibleHintViewModel(hint, accessibleValue, hintService));
        }

        public Action GetInfluentAction(string elementName, string hint, int newElementValue)
        {
            return new Action(ActionName.Influent, elementName, new InfluentialHintViewModel(hint, hintService, newElementValue));
        }

        public Action GetInfoAction(string elementName, string hint)
        {
            return new Action(ActionName.Idle, elementName, new HintViewModelBase(hint, hintService));
        }
    }
}