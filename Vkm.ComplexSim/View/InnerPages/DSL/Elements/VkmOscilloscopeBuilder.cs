using Vkm.ComplexSim.View.Elements.ViewModel;

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmOscilloscopeBuilder : BaseElementBuilder<VkmOscilloscopeBuilder, VkmOscilloscopeViewModel>
    {
        public override VkmOscilloscopeViewModel Please()
        {
            return new VkmOscilloscopeViewModel(Value, Name, PosTop, PosLeft, Page, Width, Height);
        }
    }
}