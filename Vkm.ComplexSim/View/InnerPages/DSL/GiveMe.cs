#region Usings

using System;
using Vkm.ComplexSim.View.InnerPages.DSL.Elements;
using Vkm.ComplexSim.View.InnerPages.DSL.Other;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.DSL
{
    public class GiveMe
    {
        private readonly Enum pageKey;

        public GiveMe(Enum pageKey)
        {
            this.pageKey = pageKey;
        }

        public DependencyActionBuilder DependencyAction()
        {
            return new DependencyActionBuilder();
        }
        
        public VkmBigButtonBuilder BigButton()
        {
            return new VkmBigButtonBuilder().On(pageKey);
        }

        public VkmLampBuilder Lamp()
        {
            return new VkmLampBuilder().On(pageKey);
        }

        public VkmLightableRectangleBuilder LightBox()
        {
            return new VkmLightableRectangleBuilder().On(pageKey);
        }

        public VkmBlackTriangleArrowBuilder LittleArrow()
        {
            return new VkmBlackTriangleArrowBuilder().On(pageKey);
        }

        public VkmRotateStepWheelBuilder RotateStepWheel()
        {
            return new VkmRotateStepWheelBuilder().On(pageKey);
        }

        public VkmThumblerBuilder Thumbler()
        {
            return new VkmThumblerBuilder().On(pageKey);
        }

        public VkmWheelBuilder Wheel()
        {
            return new VkmWheelBuilder().On(pageKey);
        }

        public VkmRadarTargetBuilder RadarTarget()
        {
            return new VkmRadarTargetBuilder().On(pageKey);
        }

        public VkmRadarNoiseBuilder RadarNoise()
        {
            return new VkmRadarNoiseBuilder().On(pageKey);
        }

        public VkmNumberDisplayBuilder NumberDisplay()
        {
            return new VkmNumberDisplayBuilder().On(pageKey);
        }

        public VkmOscilloscopeBuilder Oscilloscope()
        {
            return new VkmOscilloscopeBuilder().On(pageKey);
        }
    }
}