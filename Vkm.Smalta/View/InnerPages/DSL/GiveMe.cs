#region Usings

using System.Collections.Generic;
using System.Windows.Controls;
using Vkm.Smalta.View.Images;
using Vkm.Smalta.View.InnerPages.DSL.Elements;
using Vkm.Smalta.View.InnerPages.DSL.Other;

#endregion

namespace Vkm.Smalta.View.InnerPages.DSL
{
    public class GiveMe
    {
        public DependencyActionBuilder DependencyAction()
        {
            return new DependencyActionBuilder();
        }
        
        public VkmBigButtonBuilder BigButton()
        {
            return new VkmBigButtonBuilder();
        }

        public VkmLampBuilder Lamp()
        {
            return new VkmLampBuilder();
        }

        public VkmLightableRectangleBuilder LightBox()
        {
            return new VkmLightableRectangleBuilder();
        }

        public VkmBlackTriangleArrowBuilder LittleArrow()
        {
            return new VkmBlackTriangleArrowBuilder();
        }

        public VkmRotateStepWheelBuilder RotateStepWheel()
        {
            return new VkmRotateStepWheelBuilder();
        }

        public VkmThumblerBuilder Thumbler()
        {
            return new VkmThumblerBuilder();
        }

        public VkmWheelBuilder Wheel()
        {
            return new VkmWheelBuilder();
        }

        public VkmRadarTargetBuilder RadarTarget()
        {
            return new VkmRadarTargetBuilder();
        }

        public VkmRadarNoiseBuilder RadarNoise()
        {
            return new VkmRadarNoiseBuilder();
        }

        public VkmNumberDisplayBuilder NumberDisplay()
        {
            return new VkmNumberDisplayBuilder();
        }
    }
}