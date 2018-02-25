using VKMSmalta.Domain;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Dialogs.Factories
{
    public static class ActionsFactory
    {
        public static Action GetClickAction(string elementName, string hint, int accessibleValue)
        {
            return new Action(ActionName.Click, elementName, new HintViewModel(hint, accessibleValue));
        }
    }
}