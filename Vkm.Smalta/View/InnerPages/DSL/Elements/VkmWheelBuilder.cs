using System;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmWheelBuilder : BaseElementBuilder
    {
        private int minValue;
        private int maxValue;
        private int coefficient;

        public VkmWheelBuilder(int value, string name, int posTop, int posLeft, int startupRotation, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            Page = page;

            coefficient = 1;
            minValue = 0;
            maxValue = 1;
        }

        public VkmWheelBuilder WithMinValue(int minValue)
        {
            this.minValue = minValue;
            return this;
        }

        public VkmWheelBuilder WithMaxValue(int maxValue)
        {
            this.maxValue = maxValue;
            return this;
        }

        public VkmWheelBuilder WithCoefficient(int coefficient)
        {
            this.coefficient = coefficient;
            return this;
        }

        public VkmWheelViewModel Please()
        {
            var image = XamlResource.Resolve("View/Images/Wheel.png");
            return new VkmWheelViewModel(Value, image, minValue, maxValue, coefficient, Name);
        }
    }
}