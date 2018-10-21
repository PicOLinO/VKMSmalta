#region Usings

using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
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