#region Usings

using VKMSmalta.View.InnerPages.DSL.Elements;
using VKMSmalta.View.InnerPages.DSL.Other;

#endregion

namespace VKMSmalta.View.InnerPages.DSL
{
    public class GiveMe
    {
        public DependencyActionBuilder DependencyAction()
        {
            return new DependencyActionBuilder();
        }

        public BaseElementBuilder Element()
        {
            return new BaseElementBuilder();
        }
    }
}