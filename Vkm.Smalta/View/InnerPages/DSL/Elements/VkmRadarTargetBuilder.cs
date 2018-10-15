using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRadarTargetBuilder : BaseElementBuilder
    {
        public VkmRadarTargetBuilder(int value, string name, int posTop, int posLeft, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmRadarTargetViewModel Please()
        {
            return new VkmRadarTargetViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}