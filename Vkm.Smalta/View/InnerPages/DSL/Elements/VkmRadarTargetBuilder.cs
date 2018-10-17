using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRadarTargetBuilder : BaseElementBuilder<VkmRadarTargetBuilder>
    {
        public VkmRadarTargetViewModel Please()
        {
            return new VkmRadarTargetViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}