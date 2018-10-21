#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmBigButtonBuilder : BaseElementBuilder<VkmBigButtonBuilder>
    {
        private List<DependencyAction> dependencyActions;
        private string dependencySecureElementName;

        public VkmBigButtonViewModel Please()
        {
            var imageOn = ImagesRepository.BigButtonOn;
            var imageOff = ImagesRepository.BigButtonOff;
            return new VkmBigButtonViewModel(Value, Name, imageOn, imageOff, PosTop, PosLeft, Page, dependencyActions, dependencySecureElementName);
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