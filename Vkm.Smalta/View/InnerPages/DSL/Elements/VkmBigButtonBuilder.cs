#region Usings

using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmBigButtonBuilder : BaseElementBuilder
    {
        private List<DependencyAction> dependencyActions;
        private string dependencySecureElementName;

        public VkmBigButtonBuilder(int value, string name, int posTop, int posLeft, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmBigButtonViewModel Please()
        {
            var imageOn = ImagesRepository.BigButtonOn;
            var imageOff = ImagesRepository.BigButtonOff;
            return new VkmBigButtonViewModel(Value, Name, imageOn, imageOff, dependencyActions, dependencySecureElementName) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
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