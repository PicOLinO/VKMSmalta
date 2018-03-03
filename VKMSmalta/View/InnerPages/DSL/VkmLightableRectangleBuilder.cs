using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.DSL
{
    public class VkmLightableRectangleBuilder : VkmElementsBuilderBaseProps
    {
        public VkmLightableRectangleBuilder(int value, string name, int posTop, int posLeft, int startupRotation)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.rotationDegrees = startupRotation;
            this.value = value;
            this.name = name;
        }

        public VkmLightableRectangleViewModel Please()
        {
            return new VkmLightableRectangleViewModel(value, name) {PosLeft = posLeft, PosTop = posTop};
        }
    }
}