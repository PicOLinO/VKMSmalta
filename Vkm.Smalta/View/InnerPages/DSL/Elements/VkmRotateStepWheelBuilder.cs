#region Usings

using System;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmRotateStepWheelBuilder : BaseElementBuilder<VkmRotateStepWheelBuilder>
    {
        private int maxRotationSteps;
        private int rotationStepDegrees;

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