using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmLightableRectangleBuilder : BaseElementBuilder
    {
        private readonly string innerText;

        public VkmLightableRectangleBuilder(int value, string name, string innerText, int posTop, int posLeft, int startupRotation, InnerRegionPage page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
            this.page = page;
            this.innerText = innerText;
        }

        public VkmLightableRectangleViewModel Please()
        {
            return new VkmLightableRectangleViewModel(value, name, innerText) {PosLeft = posLeft, PosTop = posTop, Page = page};
        }
    }
}