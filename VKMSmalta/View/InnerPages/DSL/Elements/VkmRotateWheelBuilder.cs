using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmRotateWheelBuilder : VkmElementsBuilderBaseProps
    {
        private int rotationStepDegrees;
        private int maxRotationSteps;
        
        private readonly HistoryService historyService;

        public VkmRotateWheelBuilder(int value, string name, int posTop, int posLeft, int startupRotation, HistoryService historyService, InnerRegionPages page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
            this.historyService = historyService;
            this.page = page;
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
            var image = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/Wheel.png");
            return new VkmRotateWheelViewModel(value, name, rotationDegrees, rotationStepDegrees, maxRotationSteps, historyService, image) { PosTop = posTop, PosLeft = posLeft, Page = page};
        }
    }
}