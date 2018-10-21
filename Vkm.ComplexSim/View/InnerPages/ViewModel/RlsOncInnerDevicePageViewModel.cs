#region Usings

using System;
using System.Collections.ObjectModel;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Services.Navigate;
using Vkm.ComplexSim.View.Elements.ViewModel;
using Vkm.ComplexSim.View.InnerPages.DSL.Common;

#endregion

namespace Vkm.ComplexSim.View.InnerPages.ViewModel
{
    public class RlsOncInnerDevicePageViewModel : MainInnerDevicePageViewModel
    {
        public RlsOncInnerDevicePageViewModel(Enum pageKey, string background, Algorithm currentAlgorithm) : base(pageKey, background, currentAlgorithm)
        {
            InitializeElements();
        }

        protected sealed override void InitializeElements()
        {
            switch (PageKey)
            {
                case RlsOncInnerRegionPage.Station:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("station_stepwheel_zoom").WithValue(2).At(81, 1035).WithStartupRotation(20).WithRotationStepDegrees(32).WithMaxValue(5).Please(),
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("station_stepwheel_secodary_temp").WithValue(0).At(342, 907).WithStartupRotation(5).WithRotationStepDegrees(33).WithMaxValue(6).Please(),

                                   GiveMe.Thumbler().On(PageKey).WithName("station_thumbler_speed").WithValue(0).At(528, 671).Please(),
                                   GiveMe.Thumbler().On(PageKey).WithName("station_thumbler_direction").WithValue(0).At(528, 755).Please()
                               };
                    break;
                case RlsOncInnerRegionPage.ControlPanelSimulator:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("cps_stepwheel_noisetype").WithValue(4).At(319, 454).WithStartupRotation(-45).WithRotationStepDegrees(31).WithMaxValue(5).Please(),
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("cps_stepwheel_generator_mode").WithValue(0).At(259, 742).WithStartupRotation(-30).WithRotationStepDegrees(120).WithMaxValue(3).Please(),
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("cps_stepwheel_blocking_generator_mode").WithValue(0).At(315, 1077).WithStartupRotation(-55).WithRotationStepDegrees(30).WithMaxValue(5).Please(),

                                   GiveMe.Wheel().On(PageKey).WithName("cps_wheel_noise").WithSize(100, 100).WithValue(0).At(635, 568).WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMaxValue(50)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("radar_noise")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(0, 0)
                                                                     .WithDependencyValue(5, 10)
                                                                     .WithDependencyValue(10, 20)
                                                                     .WithDependencyValue(15, 30)
                                                                     .WithDependencyValue(20, 40)
                                                                     .WithDependencyValue(25, 50)
                                                                     .WithDependencyValue(30, 60)
                                                                     .WithDependencyValue(35, 70)
                                                                     .WithDependencyValue(40, 80)
                                                                     .WithDependencyValue(45, 90)
                                                                     .WithDependencyValue(50, 100)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Wheel().On(PageKey).WithName("cps_wheel_signal_noise").WithSize(100, 100).WithValue(25).At(638, 834).WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMaxValue(50)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("radar_target_1")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(5, 10)
                                                                     .WithDependencyValue(10, 20)
                                                                     .WithDependencyValue(15, 30)
                                                                     .WithDependencyValue(20, 40)
                                                                     .WithDependencyValue(25, 50)
                                                                     .WithDependencyValue(30, 60)
                                                                     .WithDependencyValue(35, 70)
                                                                     .WithDependencyValue(40, 80)
                                                                     .WithDependencyValue(45, 90)
                                                                     .WithDependencyValue(50, 100)
                                                                     .Please())
                                         .Please()
                               };
                    break;
                case RlsOncInnerRegionPage.G5_15:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("g515_stepwheel_timeshift").WithValue(3).At(95, 388).WithStartupRotation(40).WithRotationStepDegrees(31).WithMaxValue(6).Please(),
                                   GiveMe.RotateStepWheel().On(PageKey).WithName("g515_stepwheel_duration").WithValue(6).At(98, 905).WithStartupRotation(-50).WithRotationStepDegrees(31).WithMaxValue(10).Please(),

                                   GiveMe.NumberDisplay().On(PageKey).WithName("g515_numberdisplay_timeshift").WithValue(5).At(246, 435).Please(),
                                   GiveMe.NumberDisplay().On(PageKey).WithName("g515_numberdisplay_repetition_rate").WithValue(400).At(246, 699).Please(),
                                   GiveMe.NumberDisplay().On(PageKey).WithName("g515_numberdisplay_amplitude_measurement").WithValue(50).At(246, 960).Please(),

                                   GiveMe.Wheel().On(PageKey).WithName("g515_wheel_timeshift").WithSize(50, 50).WithValue(1).At(327, 513).WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMinValue(1).WithMaxValue(11)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("g515_numberdisplay_timeshift")
                                                                     .TypeOf(DependencyType.CoefficientReplace)
                                                                     .WithDependencyCoefficient(5)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Wheel().On(PageKey).WithName("g515_wheel_repetition_rate").WithSize(50, 50).WithValue(0).At(327, 774).WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMinValue(8).WithMaxValue(20)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("g515_numberdisplay_repetition_rate")
                                                                     .TypeOf(DependencyType.CoefficientReplace)
                                                                     .WithDependencyCoefficient(50)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Wheel().On(PageKey).WithName("g515_wheel_amplitude_measurement").WithSize(50, 50).WithValue(5).At(327, 1036).WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMinValue(1).WithMaxValue(11)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("g515_numberdisplay_amplitude_measurement")
                                                                     .TypeOf(DependencyType.CoefficientReplace)
                                                                     .WithDependencyCoefficient(10)
                                                                     .Please())
                                         .Please(),

                                   GiveMe.Lamp().On(PageKey).WithName("g515_lamp_amplitude_indicator").WithValue(1).At(237, 1244).Please(),
                                   GiveMe.Wheel().On(PageKey).WithName("g515_wheel_impulse_amplitude").WithSize(50, 50).WithValue(6).At(396, 1251).WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMinValue(1).WithMaxValue(10)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("g515_lamp_amplitude_indicator")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(5, 0)
                                                                     .WithDependencyValue(6, 1)
                                                                     .Please())
                                         .Please()
                               };
                    break;
                case RlsOncInnerRegionPage.Radar:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.RadarTarget().On(PageKey).WithName("radar_target_1").WithValue(25).At(239, 649).Please(),
                                   GiveMe.RadarNoise().On(PageKey).WithName("radar_noise").WithValue(0).WithStartupRotation(-60).At(138, 603).Please()
                               };
                    break;
                case RlsOncInnerRegionPage.C1_65:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.Thumbler().On(PageKey).WithName("c165_thumbler_scanmode_1").WithValue(1).At(116, 946)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("c165_thumbler_scanmode_0_1")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("c165_thumbler_scanmode_X")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Thumbler().On(PageKey).WithName("c165_thumbler_scanmode_0_1").WithValue(0).At(116, 976)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("c165_thumbler_scanmode_1")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("c165_thumbler_scanmode_X")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Thumbler().On(PageKey).WithName("c165_thumbler_scanmode_X").WithValue(0).At(116, 1006)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("c165_thumbler_scanmode_0_1")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("c165_thumbler_scanmode_1")
                                                                     .TypeOf(DependencyType.Replace)
                                                                     .WithDependencyValue(1, 0)
                                                                     .Please())
                                         .Please(),
                               };
                    break;
                default:
                    throw new NotSupportedException($"Unknown {nameof(PageKey)} type.");
            }
        }
    }
}