#region Usings

using VKMSmalta.View.Hints.ViewModel;

#endregion

namespace VKMSmalta.Domain
{
    public class Action
    {
        public Action(ActionName name, string parentElementName, HintViewModelBase hint = null)
        {
            Name = name;
            ParentElementName = parentElementName;
            Hint = hint;
        }

        public HintViewModelBase Hint { get; }

        public ActionName Name { get; }
        public string ParentElementName { get; }
    }
}