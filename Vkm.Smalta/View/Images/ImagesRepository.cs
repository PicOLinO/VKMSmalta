#region Usings

using XAMLEx;

#endregion

namespace Vkm.ComplexSim.View.Images
{
    public class ImagesRepository : IImagesRepository
    {
        #region IImagesRepository

        public string BigButtonOff => XamlResource.Resolve("View/Images/BigButtonOff.png");
        public string BigButtonOn => XamlResource.Resolve("View/Images/BigButtonOn.png");
        public string LampOff => XamlResource.Resolve("View/Images/LampOff.png");
        public string LampOn => XamlResource.Resolve("View/Images/LampOn.png");
        public string StepWheel => XamlResource.Resolve("View/Images/StepWheel.png");
        public string ThumblerOff => XamlResource.Resolve("View/Images/ThumblerOff.png");
        public string ThumblerOn => XamlResource.Resolve("View/Images/ThumblerOn.png");
        public string WheelGear => XamlResource.Resolve("View/Images/Wheel.png");
        public string WheelPoint => XamlResource.Resolve("View/Images/WheelPoint.png");
        public string WheelFlat => XamlResource.Resolve("View/Images/WheelFlat.png");

        public string LO01I_LO01K => XamlResource.Resolve("View/Images/Smalta/Backgrounds/LO01I_LO01K.png");
        public string LO01P => XamlResource.Resolve("View/Images/Smalta/Backgrounds/LO01P.png");
        public string LO01R => XamlResource.Resolve("View/Images/Smalta/Backgrounds/LO01R.png");

        public string rls_onc_c1_65 => XamlResource.Resolve("View/Images/RlsOnc/Backgrounds/rls_onc_c1_65.jpg");
        public string rls_onc_controlpanelsim => XamlResource.Resolve("View/Images/RlsOnc/Backgrounds/rls_onc_controlpanelsim.jpg");
        public string rls_onc_g5_15 => XamlResource.Resolve("View/Images/RlsOnc/Backgrounds/rls_onc_g5_15.jpg");
        public string rls_onc_radar => XamlResource.Resolve("View/Images/RlsOnc/Backgrounds/rls_onc_radar.jpg");
        public string rls_onc_station => XamlResource.Resolve("View/Images/RlsOnc/Backgrounds/rls_onc_station.jpg");

        #endregion
    }
}