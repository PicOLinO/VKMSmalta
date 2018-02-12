namespace VKMSmalta.Domain
{
    public class Action
    {
        public Action(ActionName name, string parentElementName)
        {
            Name = name;
            ParentElementName = parentElementName;
        }

        public ActionName Name { get; set; }
        public string ParentElementName { get; set; }
    }
}