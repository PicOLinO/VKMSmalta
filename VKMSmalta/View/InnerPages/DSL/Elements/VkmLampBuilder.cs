#region Usings

using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using XAMLEx;

#endregion

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmLampBuilder : BaseElementBuilder
    {
        public VkmLampBuilder(int value, string name, int posTop, int posLeft, InnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmLampViewModel Please()
        {
            var imageOn = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/LampOn.png");
            var imageOff = ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/LampOff.png");
            return new VkmLampViewModel(Value, Name, imageOn, imageOff) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
        }
    }
}