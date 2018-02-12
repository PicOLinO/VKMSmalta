using VKMSmalta.View.ViewModel;

namespace VKMSmalta.Domain
{
    public class Action
    {
        public Action(ActionName name, string parentElementName, HintViewModel hint = null)
        {
            Name = name;
            ParentElementName = parentElementName;
            Hint = hint;
        }

        public ActionName Name { get; set; }
        public string ParentElementName { get; set; }
        public HintViewModel Hint { get; set; }
    }
}