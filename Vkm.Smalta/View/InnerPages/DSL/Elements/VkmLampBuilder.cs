#region Usings

using System;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmLampBuilder : BaseElementBuilder<VkmLampBuilder>
    {
        public VkmLampViewModel Please()
        {
            var imageOn = ImagesRepository.LampOn;
            var imageOff = ImagesRepository.LampOff;
            return new VkmLampViewModel(Value, Name, imageOn, imageOff, PosTop, PosLeft, Page);
        }
    }
}