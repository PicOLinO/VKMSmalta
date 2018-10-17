using System;
using Vkm.Smalta.View.Elements.ViewModel;

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class VkmNumberDisplayBuilder : BaseElementBuilder<VkmNumberDisplayBuilder>
    {
        public VkmNumberDisplayViewModel Please()
        {
            return new VkmNumberDisplayViewModel(Value, Name, PosTop, PosLeft, Page);
        }
    }
}