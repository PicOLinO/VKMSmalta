using System;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.InnerPages.DSL.Common;
using XAMLEx;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmWheelBuilder : BaseElementBuilder
    {
        private int minValue;
        private int maxValue;
        private int coefficient;
        private string image;

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

        public VkmWheelBuilder WithImageType(ImageType imageType)
        {
            switch (imageType)
            {
                case ImageType.Flat:
                    image = ImagesRepository.WheelFlat;
                    break;
                case ImageType.Point:
                    image = ImagesRepository.WheelPoint;
                    break;
                case ImageType.Gear:
                    image = ImagesRepository.WheelGear;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(imageType), imageType, null);
            }

            return this;
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
            return new VkmWheelViewModel(Value, image, minValue, maxValue, coefficient, Name) { PosTop = PosTop, PosLeft = PosLeft, Page = Page };
        }
    }
}