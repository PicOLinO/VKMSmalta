using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.DSL
{
    public class VkmThumblerBuilder : VkmElementsBuilderBaseProps
    {
        private readonly HistoryService historyService;

        private List<DependencyAction> dependencyActions;

        public VkmThumblerBuilder(int value, string name, int posTop, int posLeft, int startupRotation, HistoryService historyService)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
            this.historyService = historyService;
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
            return new VkmThumblerViewModel(value, name, historyService, dependencyActions) {PosTop = posTop, PosLeft = posLeft, StartupRotation = rotationDegrees};
        }
    }
}