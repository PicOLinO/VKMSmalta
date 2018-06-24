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
    public class VkmBigButtonBuilder : BaseElementBuilder
    {
        private readonly HistoryService historyService;

        private List<DependencyAction> dependencyActions;
        private string dependencySecureElementName;

        public VkmBigButtonBuilder(int value, string name, int posTop, int posLeft, HistoryService historyService, InnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            this.historyService = historyService;
            Page = page;
        }

        public VkmBigButtonViewModel Please()
        {
            var imageOn = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/BigButtonOn.png");
            var imageOff = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/BigButtonOff.png");
            return new VkmBigButtonViewModel(Value, Name, historyService, imageOn, imageOff, dependencyActions, dependencySecureElementName) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
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

        public VkmBigButtonBuilder WithDependencySecureElement(string dependencySecureElementName)
        {
            this.dependencySecureElementName = dependencySecureElementName;
            return this;
        }
    }
}