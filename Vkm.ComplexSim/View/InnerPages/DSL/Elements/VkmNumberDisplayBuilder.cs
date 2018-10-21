using Vkm.ComplexSim.View.Elements.ViewModel;

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmNumberDisplayBuilder : BaseElementBuilder<VkmNumberDisplayBuilder>
    {
        public VkmNumberDisplayViewModel Please()
        {
            return new VkmNumberDisplayViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}