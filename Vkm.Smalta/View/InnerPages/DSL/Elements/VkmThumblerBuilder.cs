#region Usings

using System;
using System.Collections.Generic;
using Vkm.Smalta.Domain;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmThumblerBuilder : BaseElementBuilder
    {
        private List<DependencyAction> dependencyActions;

        public VkmThumblerBuilder(int value, string name, int posTop, int posLeft, int startupRotation, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmThumblerViewModel Please()
        {
            var imageOn = ImagesRepository.ThumblerOn;
            var imageOff = ImagesRepository.ThumblerOff;
            return new VkmThumblerViewModel(Value, Name, imageOff, imageOn, dependencyActions) {PosTop = PosTop, PosLeft = PosLeft, StartupRotation = RotationDegrees, Page = Page};
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