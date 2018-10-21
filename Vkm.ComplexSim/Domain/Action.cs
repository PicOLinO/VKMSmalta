#region Usings

using Vkm.ComplexSim.View.Hints.ViewModel;

#endregion

namespace Vkm.ComplexSim.Domain
{
    public class Action
    {
        public Action(ActionName name, string parentElementName, bool useInExamineCheck = true, HintViewModelBase hint = null)
        {
            Name = name;
            ParentElementName = parentElementName;
            UseInExamineCheck = useInExamineCheck;
            Hint = hint;
        }

        public HintViewModelBase Hint { get; }

        public ActionName Name { get; }
        public string ParentElementName { get; }
        public bool UseInExamineCheck { get; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ParentElementName)}: {ParentElementName}";
        }
    }
}