#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmThumblerBuilder : BaseElementBuilder<VkmThumblerBuilder>
    {
        private List<DependencyAction> dependencyActions;

        public VkmThumblerViewModel Please()
        {
            var imageOn = ImagesRepository.ThumblerOn;
            var imageOff = ImagesRepository.ThumblerOff;
            return new VkmThumblerViewModel(Value, Name, imageOff, imageOn, RotationDegrees, PosTop, PosLeft, Page, dependencyActions);
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