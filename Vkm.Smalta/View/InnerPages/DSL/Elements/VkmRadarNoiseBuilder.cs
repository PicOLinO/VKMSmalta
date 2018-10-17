using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRadarNoiseBuilder : BaseElementBuilder<VkmRadarNoiseBuilder>
    {
        public VkmRadarNoiseViewModel Please()
        {
            return new VkmRadarNoiseViewModel(Value, Name, RotationDegrees, PosTop, PosLeft, Page);
        }
    }
}