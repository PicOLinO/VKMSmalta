using Vkm.ComplexSim.View.Elements.ViewModel;

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmRadarTargetBuilder : BaseElementBuilder<VkmRadarTargetBuilder, VkmRadarTargetViewModel>
    {
        public override VkmRadarTargetViewModel Please()
        {
            return new VkmRadarTargetViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}