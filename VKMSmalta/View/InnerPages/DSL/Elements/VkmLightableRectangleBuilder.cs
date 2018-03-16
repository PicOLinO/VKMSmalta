using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmLightableRectangleBuilder : BaseElementBuilder
    {
        public VkmLightableRectangleBuilder(int value, string name, int posTop, int posLeft, int startupRotation, InnerRegionPage page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
            this.page = page;
        }

        public VkmLightableRectangleViewModel Please()
        {
            return new VkmLightableRectangleViewModel(value, name) {PosLeft = posLeft, PosTop = posTop, Page = page};
        }
    }
}