using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
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
        private List<DependencyAction> dependencyActions;

        public VkmWheelBuilder(int value, string name, int posTop, int posLeft, int width, int height, int startupRotation, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            Page = page;
            Width = width;
            Height = height;

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

        public VkmWheelBuilder WithDependencyAction(DependencyAction dependencyAction)
        {
            if (dependencyActions == null)
            {
                dependencyActions = new List<DependencyAction>();
            }

            dependencyActions.Add(dependencyAction);
            return this;
        }

        public VkmWheelViewModel Please()
        {
            return new VkmWheelViewModel(Value, image, minValue, maxValue, coefficient, dependencyActions, Name, PosTop, PosLeft, Width, Height, Page);
        }
    }
}