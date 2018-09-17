#region Usings

using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmLampBuilder : BaseElementBuilder
    {
        public VkmLampBuilder(int value, string name, int posTop, int posLeft, SmaltaInnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmLampViewModel Please()
        {
            var imageOn = XamlResource.Resolve("View/Images/LampOn.png");
            var imageOff = XamlResource.Resolve("View/Images/LampOff.png");
            return new VkmLampViewModel(Value, Name, imageOn, imageOff) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
        }
    }
}