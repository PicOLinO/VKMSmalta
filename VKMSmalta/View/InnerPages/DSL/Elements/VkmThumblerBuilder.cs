#region Usings

using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmThumblerBuilder : BaseElementBuilder
    {
        private readonly HistoryService historyService;

        private List<DependencyAction> dependencyActions;

        public VkmThumblerBuilder(int value, string name, int posTop, int posLeft, int startupRotation, HistoryService historyService, InnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            this.historyService = historyService;
            Page = page;
        }

        public VkmThumblerViewModel Please()
        {
            var imageOn = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/ThumblerOn.png");
            var imageOff = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/ThumblerOff.png");
            return new VkmThumblerViewModel(Value, Name, historyService, imageOff, imageOn, dependencyActions) {PosTop = PosTop, PosLeft = PosLeft, StartupRotation = RotationDegrees, Page = Page};
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
    }
}