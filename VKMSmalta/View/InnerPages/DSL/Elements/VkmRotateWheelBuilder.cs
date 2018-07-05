#region Usings

using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
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
            var image = XamlResource.Resolve("View/Images/Wheel.png");
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