using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmThumblerBuilder : VkmElementsBuilderBaseProps
    {
        private readonly HistoryService historyService;

        private List<DependencyAction> dependencyActions;

        public VkmThumblerBuilder(int value, string name, int posTop, int posLeft, int startupRotation, HistoryService historyService, InnerRegionPage page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
            this.historyService = historyService;
            this.page = page;
        }
        
        public VkmThumblerBuilder WithDependencyAction(DependencyAction dependencyAction)
        {
            if (dependencyActions == null)
            {
                dependencyActions = new List<DependencyAction>();
            }
            dependencyActions.Add(dependencyAction);
            return this;
        }
        
        public VkmThumblerViewModel Please()
        {
            var imageOn = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/ThumblerOn.png");
            var imageOff = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/ThumblerOff.png");
            return new VkmThumblerViewModel(value, name, historyService, imageOff, imageOn, dependencyActions) {PosTop = posTop, PosLeft = posLeft, StartupRotation = rotationDegrees, Page = page};
        }
    }
}