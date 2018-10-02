#region Usings

using System;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmLampBuilder : BaseElementBuilder
    {
        public VkmLampBuilder(int value, string name, int posTop, int posLeft, Enum page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmLampViewModel Please()
        {
            var imageOn = ImagesRepository.LampOn;
            var imageOff = ImagesRepository.LampOff;
            return new VkmLampViewModel(Value, Name, imageOn, imageOff) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
        }
    }
}