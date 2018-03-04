using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.DSL
{
    public class VkmRotateWheelBuilder : VkmElementsBuilderBaseProps
    {
        private int rotationStepDegrees;
        private int maxRotationSteps;
        
        private readonly HistoryService historyService;

        public VkmRotateWheelBuilder(int value, string name, int posTop, int posLeft, int startupRotation, HistoryService historyService)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
            this.historyService = historyService;
        }

        public VkmRotateWheelBuilder WithRotationStepDegrees(int rotationStepDegrees)
        {
            this.rotationStepDegrees = rotationStepDegrees;
            return this;
        }

        public VkmRotateWheelBuilder WithMaxValue(int maxRotationSteps)
        {
            this.maxRotationSteps = maxRotationSteps;
            return this;
        }

        public VkmRotateWheelViewModel Please()
        {
            return new VkmRotateWheelViewModel(value, name, rotationDegrees, rotationStepDegrees, maxRotationSteps, historyService) { PosTop = posTop, PosLeft = posLeft };
        }
    }
}