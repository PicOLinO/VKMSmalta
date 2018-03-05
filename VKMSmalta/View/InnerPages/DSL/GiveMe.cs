using VKMSmalta.View.DSL.Other;
using VKMSmalta.View.InnerPages.DSL.Elements;

namespace VKMSmalta.View.DSL
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