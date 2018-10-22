#region Usings

using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmRotateStepWheelBuilder : BaseElementBuilder<VkmRotateStepWheelBuilder, VkmRotateStepWheelViewModel>
    {
        private int maxRotationSteps;
        private int rotationStepDegrees;

        public override VkmRotateStepWheelViewModel Please()
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