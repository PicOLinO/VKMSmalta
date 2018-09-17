#region Usings

using System.Windows.Media;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmLightableRectangleBuilder : BaseElementBuilder
    {
        private readonly string innerText;
        private Color backgroundColor = Colors.White;

        public VkmLightableRectangleBuilder(int value, string name, string innerText, int posTop, int posLeft, int startupRotation, SmaltaInnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            Page = page;
            this.innerText = innerText;
        }

        public VkmLightableRectangleViewModel Please()
        {
            return new VkmLightableRectangleViewModel(Value, Name, innerText, backgroundColor) {PosLeft = PosLeft, PosTop = PosTop, Page = Page};
        }

        public VkmLightableRectangleBuilder WithBackgroundColor(Color color)
        {
            backgroundColor = color;
            return this;
        }
    }
}