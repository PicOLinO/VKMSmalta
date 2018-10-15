using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRadarNoiseBuilder : BaseElementBuilder
    {
        public VkmRadarNoiseBuilder(int value, string name, int posTop, int posLeft, int rotationDegrees, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
            RotationDegrees = rotationDegrees;
        }

        public VkmRadarNoiseViewModel Please()
        {
            return new VkmRadarNoiseViewModel(Value, Name, RotationDegrees, PosTop, PosLeft, Page);
        }
    }
}