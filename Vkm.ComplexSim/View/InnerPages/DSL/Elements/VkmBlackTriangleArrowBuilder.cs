#region Usings

using Vkm.ComplexSim.View.Elements.ViewModel;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmBlackTriangleArrowBuilder : BaseElementBuilder<VkmBlackTriangleArrowBuilder, VkmBlackTriangleArrowViewModel>
    {
        public override VkmBlackTriangleArrowViewModel Please()
        {
            return new VkmBlackTriangleArrowViewModel(Value, Name, RotationDegrees, PosTop, PosLeft, Page);
        }
    }
}