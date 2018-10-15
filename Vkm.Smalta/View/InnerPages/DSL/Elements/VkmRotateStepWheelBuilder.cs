#region Usings

using System;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRotateStepWheelBuilder : BaseElementBuilder
    {
        private int maxRotationSteps;
        private int rotationStepDegrees;

        public VkmRotateStepWheelBuilder(int value, string name, int posTop, int posLeft, int startupRotation, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmRotateStepWheelViewModel Please()
        {
            var image = ImagesRepository.StepWheel;
            return new VkmRotateStepWheelViewModel(Value, Name, RotationDegrees, rotationStepDegrees, maxRotationSteps, image, PosTop, PosLeft, Page);
        }

        public VkmRotateStepWheelBuilder WithMaxValue(int maxRotationSteps)
        {
            this.maxRotationSteps = maxRotationSteps;
            return this;
        }

        public VkmRotateStepWheelBuilder WithRotationStepDegrees(int rotationStepDegrees)
        {
            this.rotationStepDegrees = rotationStepDegrees;
            return this;
        }
    }
}