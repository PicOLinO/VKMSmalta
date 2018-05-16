using System.Windows.Media;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmLightableRectangleBuilder : BaseElementBuilder
    {
        private readonly string innerText;
        private Color backgroundColor = Colors.White;

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

        public VkmLightableRectangleBuilder WithBackgroundColor(Color color)
        {
            backgroundColor = color;
            return this;
        }

        public VkmLightableRectangleViewModel Please()
        {
            return new VkmLightableRectangleViewModel(value, name, innerText, backgroundColor) {PosLeft = posLeft, PosTop = posTop, Page = page};
        }
    }
}