using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmNumberDisplayBuilder : BaseElementBuilder
    {
        public VkmNumberDisplayViewModel Please()
        {
            return new VkmNumberDisplayViewModel(Value, Name) { PosTop = PosTop, PosLeft = PosLeft, Page = Page };
        }
    }
}