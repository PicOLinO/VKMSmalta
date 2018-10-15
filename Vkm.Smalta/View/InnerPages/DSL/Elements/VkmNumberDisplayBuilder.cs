using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmNumberDisplayBuilder : BaseElementBuilder
    {
        public VkmNumberDisplayBuilder(int value, string name, int posTop, int posLeft, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmNumberDisplayViewModel Please()
        {
            return new VkmNumberDisplayViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}