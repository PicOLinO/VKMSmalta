#region Usings

using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.Hints.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs.Factories
{
    public class ActionsFactory : IActionsFactory
    {
        public Action GetClickAction(string elementName, string hint, int accessibleValue, bool useInExamineCheck = true)
        {
            return new Action(ActionName.Click, elementName, useInExamineCheck, new AccessibleHintViewModel(hint, accessibleValue));
        }

        public Action GetIdleAction(string elementName, string hint, int accessibleValue, bool useInExamineCheck = false)
        {
            return new Action(ActionName.Idle, elementName, useInExamineCheck, new AccessibleHintViewModel(hint, accessibleValue));
        }

        public Action GetInfluentAction(string elementName, string hint, int newElementValue, bool useInExamineCheck = false)
        {
            return new Action(ActionName.Influent, elementName, useInExamineCheck, new InfluentialHintViewModel(hint, newElementValue));
        }

        public Action GetInfoAction(string elementName, string hint, bool useInExamineCheck = false)
        {
            return new Action(ActionName.Idle, elementName, useInExamineCheck, new HintViewModelBase(hint));
        }
    }
}