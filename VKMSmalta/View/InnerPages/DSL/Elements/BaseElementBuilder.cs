using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;

namespace VKMSmalta.View.InnerPages.DSL.Elements
{
    public class BaseElementBuilder
    {
        protected int posTop;
        protected int posLeft;
        protected int value;
        protected string name;
        protected int rotationDegrees;
        protected InnerRegionPage page;

        public BaseElementBuilder WithValue(int value)
        {
            this.value = value;
            return this;
        }

        public BaseElementBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public BaseElementBuilder WithStartupRotation(int rotationDegrees)
        {
            this.rotationDegrees = rotationDegrees;
            return this;
        }

        public BaseElementBuilder At(int posTop, int posLeft)
        {
            this.posTop = posTop;
            this.posLeft = posLeft;
            return this;
        }

        public BaseElementBuilder On(InnerRegionPage page)
        {
            this.page = page;
            return this;
        }

        public VkmThumblerBuilder Thumbler(HistoryService historyService)
        {
            return new VkmThumblerBuilder(value, name, posTop, posLeft, rotationDegrees, historyService, page);
        }

        public VkmRotateWheelBuilder RotateWheel(HistoryService historyService)
        {
            return new VkmRotateWheelBuilder(value, name, posTop, posLeft, rotationDegrees, historyService, page);
        }

        public VkmBlackTriangleArrowBuilder LittleArrow()
        {
            return new VkmBlackTriangleArrowBuilder(value, name, posTop, posLeft, rotationDegrees, page);
        }

        public VkmLightableRectangleBuilder LightBox()
        {
            return new VkmLightableRectangleBuilder(value, name, posTop, posLeft, rotationDegrees, page);
        }

        public VkmBigButtonBuilder BigButton(HistoryService historyService)
        {
            return new VkmBigButtonBuilder(value, name, posTop, posLeft, historyService, page);
        }

        public VkmLampBuilder Lamp()
        {
            return new VkmLampBuilder(value, name, posTop, posLeft, page);
        }
    }
}