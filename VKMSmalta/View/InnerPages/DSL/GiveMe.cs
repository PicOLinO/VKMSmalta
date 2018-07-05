#region Usings

using Vkm.Smalta.View.InnerPages.DSL.Elements;
using Vkm.Smalta.View.InnerPages.DSL.Other;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL
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