using VKMSmalta.View.InnerPages.DSL.Elements;
using VKMSmalta.View.InnerPages.DSL.Other;

namespace VKMSmalta.View.InnerPages.DSL
{
    public class GiveMe
    {
        public BaseElementBuilder Element()
        {
            return new BaseElementBuilder();
        }

        public DependencyActionBuilder DependencyAction()
        {
            return new DependencyActionBuilder();
        }
    }
}