using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmBigButtonBuilder : VkmElementsBuilderBaseProps
    {
        private readonly HistoryService historyService;

        private List<DependencyAction> dependencyActions;

        public VkmBigButtonBuilder(int value, string name, int posTop, int posLeft, HistoryService historyService, InnerRegionPage page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.value = value;
            this.name = name;
            this.historyService = historyService;
            this.page = page;
        }

        public VkmBigButtonBuilder WithDependencyAction(DependencyAction dependencyAction)
        {
            if (dependencyActions == null)
            {
                dependencyActions = new List<DependencyAction>();
            }
            dependencyActions.Add(dependencyAction);
            return this;
        }

        public VkmBigButtonViewModel Please()
        {
            var imageOn = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/BigButtonOn.png");
            var imageOff = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/BigButtonOff.png");
            return new VkmBigButtonViewModel(value, name, historyService, imageOn, imageOff, dependencyActions) {PosTop = posTop, PosLeft = posLeft, Page = page};
        }
    }
}