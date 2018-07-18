#region Usings

using Vkm.Smalta.View.Hints.ViewModel;

#endregion

namespace Vkm.Smalta.Domain
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

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ParentElementName)}: {ParentElementName}";
        }
    }
}