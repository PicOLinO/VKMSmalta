using Vkm.ComplexSim.View.Elements.ViewModel;

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmRadarNoiseBuilder : BaseElementBuilder<VkmRadarNoiseBuilder>
    {
        public VkmRadarNoiseViewModel Please()
        {
            return new VkmRadarNoiseViewModel(Value, Name, RotationDegrees, PosTop, PosLeft, Page);
        }
    }
}