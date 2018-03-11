using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class VkmBigButtonBuilder : VkmElementsBuilderBaseProps
    {
        private readonly HistoryService historyService;

        public VkmBigButtonBuilder(int value, string name, int posTop, int posLeft, HistoryService historyService, InnerRegionPage page)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            this.value = value;
            this.name = name;
            this.historyService = historyService;
            this.page = page;
        }

        public VkmBigButtonViewModel Please()
        {
            var imageOn = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/BigButtonOn.png");
            var imageOff = XAMLEx.ResourcesHelper.GetDefaultResource(DependencyContainer.AssemblyName, "View/Images/BigButtonOff.png");
            return new VkmBigButtonViewModel(value, name, historyService, imageOn, imageOff) {PosTop = posTop, PosLeft = posLeft, Page = page};
        }
    }
}