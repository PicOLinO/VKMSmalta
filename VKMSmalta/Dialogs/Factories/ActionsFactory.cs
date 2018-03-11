using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Hints.ViewModel;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Dialogs.Factories
{
    public class ActionsFactory
    {
        private readonly HintService hintService;

        public ActionsFactory(HintService hintService)
        {
            this.hintService = hintService;
        }

        public Action GetClickAction(string elementName, string hint, int accessibleValue)
        {
            return new Action(ActionName.Click, elementName, new AccessibleHintViewModel(hint, accessibleValue, hintService));
        }

        public Action GetInfluentAction(string elementName, string hint, int newElementValue)
        {
            return new Action(ActionName.Influent, elementName, new InfluentialHintViewModel(hint, hintService, newElementValue));
        }
    }
}