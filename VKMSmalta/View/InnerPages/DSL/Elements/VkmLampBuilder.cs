using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmLampBuilder : VkmElementsBuilderBaseProps
    {
        public VkmLampBuilder(int value, string name, int posTop, int posLeft, InnerRegionPage page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.value = value;
            this.name = name;
            this.page = page;
        }

        public VkmLampViewModel Please()
        {
            var imageOn = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/LampOn.png");
            var imageOff = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/LampOff.png");
            return new VkmLampViewModel(value, name, imageOn, imageOff) { PosTop = posTop, PosLeft = posLeft, Page = page };
        }
    }
}