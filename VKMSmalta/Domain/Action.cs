namespace VKMSmalta.Domain
{
    public class Action
    {
        public Action(ActionName name, string parent)
        {
            Name = name;
            Parent = parent;
        }

        public ActionName Name { get; set; }
        public string Parent { get; set; }
    }
}