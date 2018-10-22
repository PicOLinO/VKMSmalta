using Vkm.ComplexSim.View.Elements.ViewModel;

namespace Vkm.ComplexSim.View.InnerPages.DSL.Elements
{
    public class VkmNumberDisplayBuilder : BaseElementBuilder<VkmNumberDisplayBuilder, VkmNumberDisplayViewModel>
    {
        public override VkmNumberDisplayViewModel Please()
        {
            return new VkmNumberDisplayViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}