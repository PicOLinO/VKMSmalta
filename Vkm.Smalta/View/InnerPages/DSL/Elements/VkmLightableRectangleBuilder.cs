#region Usings

using System.Windows.Media;
using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmLightableRectangleBuilder : BaseElementBuilder<VkmLightableRectangleBuilder>
    {
        private string innerText;
        private Color backgroundColor = Colors.White;

        public VkmLightableRectangleViewModel Please()
        {
            return new VkmLightableRectangleViewModel(Value, Name, innerText, backgroundColor, PosTop, PosLeft, Page);
        }

        public VkmLightableRectangleBuilder WithText(string innerText)
        {
            this.innerText = innerText;
            return this;
        }

        public VkmLightableRectangleBuilder WithBackgroundColor(Color color)
        {
            backgroundColor = color;
            return this;
        }
    }
}