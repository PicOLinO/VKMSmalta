using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmBlackTriangleArrowBuilder : VkmElementsBuilderBaseProps
    {
        public VkmBlackTriangleArrowBuilder(int value, string name, int posTop, int posLeft, int startupRotation)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
        }

        public VkmBlackTriangleArrowViewModel Please()
        {
            return new VkmBlackTriangleArrowViewModel(value, name, rotationDegrees) {PosTop = posTop, PosLeft = posLeft};
        }
    }
}