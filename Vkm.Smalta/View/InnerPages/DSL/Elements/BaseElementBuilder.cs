#region Usings

using System;
using System.Collections.Generic;
using DevExpress.Mvvm;
using Vkm.Smalta.View.Images;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL.Elements
{
    public class BaseElementBuilder
    {
        protected string Name;
        protected Enum Page;
        protected int PosLeft;
        protected int PosTop;
        protected int RotationDegrees;
        protected int Value;
        protected int Width;
        protected int Height;

        protected IImagesRepository ImagesRepository => ServiceContainer.Default.GetService<IImagesRepository>();

        public BaseElementBuilder WithSize(int width, int height)
        {
            Width = width;
            Height = height;
            return this;
        }

        public BaseElementBuilder At(int posTop, int posLeft)
        {
            PosTop = posTop;
            PosLeft = posLeft;
            return this;
        }

        public VkmBigButtonBuilder BigButton()
        {
            return new VkmBigButtonBuilder(Value, Name, PosTop, PosLeft, Page);
        }

        public VkmLampBuilder Lamp()
        {
            return new VkmLampBuilder(Value, Name, PosTop, PosLeft, Page);
        }

        public VkmLightableRectangleBuilder LightBox(string innerText)
        {
            return new VkmLightableRectangleBuilder(Value, Name, innerText, PosTop, PosLeft, RotationDegrees, Page);
        }

        public VkmBlackTriangleArrowBuilder LittleArrow()
        {
            return new VkmBlackTriangleArrowBuilder(Value, Name, PosTop, PosLeft, RotationDegrees, Page);
        }

        public BaseElementBuilder On(Enum page)
        {
            Page = page;
            return this;
        }

        public VkmRotateStepWheelBuilder RotateStepWheel()
        {
            return new VkmRotateStepWheelBuilder(Value, Name, PosTop, PosLeft, RotationDegrees, Page);
        }

        public VkmThumblerBuilder Thumbler()
        {
            return new VkmThumblerBuilder(Value, Name, PosTop, PosLeft, RotationDegrees, Page);
        }

        public VkmWheelBuilder Wheel()
        {
            return new VkmWheelBuilder(Value, Name, PosTop, PosLeft, Width, Height, RotationDegrees, Page);
        }

        public VkmRadarTargetBuilder RadarTarget()
        {
            return new VkmRadarTargetBuilder(Value, Name, PosTop, PosLeft, Page);
        }

        public VkmRadarNoiseBuilder RadarNoise()
        {
            return new VkmRadarNoiseBuilder(Value, Name, PosTop, PosLeft, RotationDegrees, Page);
        }

        public VkmNumberDisplayBuilder NumberDisplay()
        {
            return new VkmNumberDisplayBuilder(Value, Name, PosTop, PosLeft, Page);
        }

        public BaseElementBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public BaseElementBuilder WithStartupRotation(int rotationDegrees)
        {
            RotationDegrees = rotationDegrees;
            return this;
        }

        public BaseElementBuilder WithValue(int value)
        {
            Value = value;
            return this;
        }

        public BaseElementBuilder WithValueFrom(IDictionary<string, int> startupValuesDictionary, int defaultValue = 0)
        {
            Value = startupValuesDictionary.TryGetValue(Name, out var value)
                        ? value
                        : defaultValue;
            return this;
        }
    }
}