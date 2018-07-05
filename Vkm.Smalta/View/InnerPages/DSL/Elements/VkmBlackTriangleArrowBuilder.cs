#region Usings

using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmBlackTriangleArrowBuilder : BaseElementBuilder
    {
        public VkmBlackTriangleArrowBuilder(int value, string name, int posTop, int posLeft, int startupRotation, InnerRegionPage page)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            RotationDegrees = startupRotation;
            Value = value;
            Name = name;
            Page = page;
        }

        public VkmBlackTriangleArrowViewModel Please()
        {
            return new VkmBlackTriangleArrowViewModel(Value, Name, RotationDegrees) {PosTop = PosTop, PosLeft = PosLeft, Page = Page};
        }
    }
}