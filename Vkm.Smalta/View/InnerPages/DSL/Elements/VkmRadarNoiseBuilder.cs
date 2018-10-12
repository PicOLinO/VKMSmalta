using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRadarNoiseBuilder : BaseElementBuilder
    {
        private int opacityPercent;

        public VkmRadarNoiseBuilder(int value, string name, int posTop, int posLeft, int rotationDegrees, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
            RotationDegrees = rotationDegrees;
        }

        public VkmRadarNoiseBuilder WithOpacityPercents(int opacityPercent)
        {
            this.opacityPercent = opacityPercent;
            return this;
        }

        public VkmRadarNoiseViewModel Please()
        {
            return new VkmRadarNoiseViewModel(Value, Name) { PosLeft = PosLeft, PosTop = PosTop, Page = Page, OpacityPercents = opacityPercent, RotationDegrees = RotationDegrees};
        }
    }
}