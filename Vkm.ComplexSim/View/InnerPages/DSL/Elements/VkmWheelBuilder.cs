using System;
using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Vkm.ComplexSim.View.InnerPages.DSL.Common;

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmWheelBuilder : BaseElementBuilder<VkmWheelBuilder, VkmWheelViewModel>
    {
        private int minValue;
        private int maxValue;
        private int rotationCoefficient;
        private string image;
        private List<DependencyAction> dependencyActions;

        public VkmWheelBuilder()
        {
            rotationCoefficient = 1;
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

        public VkmWheelBuilder WithRotationCoefficient(int coefficient)
        {
            this.rotationCoefficient = coefficient;
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

        public override VkmWheelViewModel Please()
        {
            return new VkmWheelViewModel(Value, image, minValue, maxValue, rotationCoefficient, dependencyActions, Name, PosTop, PosLeft, Width, Height, Page);
        }
    }
}