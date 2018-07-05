#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
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
            var imageOn = XamlResource.Resolve("View/Images/BigButtonOn.png");
            var imageOff = XamlResource.Resolve("View/Images/BigButtonOff.png");
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