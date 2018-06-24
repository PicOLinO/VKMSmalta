#region Usings

using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmRotateWheelBuilder : BaseElementBuilder
    {
        private readonly HistoryService historyService;
        private int maxRotationSteps;
        private int rotationStepDegrees;

        public VkmRotateWheelBuilder(int value, string name, int posTop, int posLeft, int startupRotation, HistoryService historyService, InnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            this.historyService = historyService;
            Page = page;
        }

        public VkmRotateWheelViewModel Please()
        {
            var image = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/Wheel.png");
            return new VkmRotateWheelViewModel(Value, Name, RotationDegrees, rotationStepDegrees, maxRotationSteps, historyService, image) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
        }

        public VkmRotateWheelBuilder WithMaxValue(int maxRotationSteps)
        {
            this.maxRotationSteps = maxRotationSteps;
            return this;
        }

        public VkmRotateWheelBuilder WithRotationStepDegrees(int rotationStepDegrees)
        {
            this.rotationStepDegrees = rotationStepDegrees;
            return this;
        }
    }
}