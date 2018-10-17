#region Usings

using System;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmBlackTriangleArrowBuilder : BaseElementBuilder<VkmBlackTriangleArrowBuilder>
    {
        public VkmBlackTriangleArrowViewModel Please()
        {
            return new VkmBlackTriangleArrowViewModel(Value, Name, RotationDegrees, PosTop, PosLeft, Page);
        }
    }
}