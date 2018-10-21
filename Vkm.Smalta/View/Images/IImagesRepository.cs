namespace Vkm.ComplexSim.View.Images
{
    public interface IImagesRepository
    {
        string BigButtonOff { get; }
        string BigButtonOn { get; }
        string LampOff { get; }
        string LampOn { get; }
        string StepWheel { get; }
        string ThumblerOff { get; }
        string ThumblerOn { get; }
        string WheelGear { get; }
        string WheelPoint { get; }
        string WheelFlat { get; }

        string LO01I_LO01K { get; }
        string LO01P { get; }
        string LO01R { get; }

        string rls_onc_c1_65 { get; }
        string rls_onc_controlpanelsim { get; }
        string rls_onc_g5_15 { get; }
        string rls_onc_radar { get; }
        string rls_onc_station { get; }
    }
}