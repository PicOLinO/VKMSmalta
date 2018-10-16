#region Usings

using System;
using System.Collections.ObjectModel;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.InnerPages.DSL.Common;

#endregion

namespace Vkm.Smalta.View.InnerPages.ViewModel
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
                    Elements = new ObservableCollection<ElementViewModelBase>();
                    break;
                case RlsOncInnerRegionPage.ControlPanelSimulator:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.Element().On(PageKey).WithName("cps_wheel_signal").WithSize(100, 100).WithValue(0).At(635, 568).Wheel().WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMaxValue(40).Please(),
                                   GiveMe.Element().On(PageKey).WithName("cps_wheel_signal_noise").WithSize(100, 100).WithValue(0).At(638, 834).Wheel().WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMaxValue(40).Please(),
                               };
                    break;
                case RlsOncInnerRegionPage.G5_15:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.Element().On(PageKey).WithName("g515_numberdisplay_timeshift").WithValue(10).At(246, 435).NumberDisplay().Please(),
                                   GiveMe.Element().On(PageKey).WithName("g515_numberdisplay_repetition_rate").WithValue(0).At(246, 699).NumberDisplay().Please(),
                                   GiveMe.Element().On(PageKey).WithName("g515_numberdisplay_amplitude_measurement").WithValue(0).At(246, 960).NumberDisplay().Please(),

                                   GiveMe.Element().On(PageKey).WithName("g515_stepwheel_timeshift").WithValue(0).At(91, 387).WithStartupRotation(60).RotateStepWheel().WithRotationStepDegrees(60).WithMaxValue(3).Please(),
                                   GiveMe.Element().On(PageKey).WithName("g515_stepwheel_duration").WithValue(0).At(98, 905).WithStartupRotation(-50).RotateStepWheel().WithRotationStepDegrees(31).WithMaxValue(10).Please(),
                                   
                                   GiveMe.Element().On(PageKey).WithName("g515_wheel_timeshift").WithSize(50, 50).WithValue(10).At(327, 513).Wheel().WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMinValue(10).WithMaxValue(55)
                                         .WithDependencyAction(GiveMe.DependencyAction()
                                                                     .WithDependencyElementName("g515_numberdisplay_timeshift")
                                                                     .TypeOf(DependencyType.CoefficientReplace)
                                                                     .WithDependencyCoefficient(1)
                                                                     .Please())
                                         .Please(),
                                   GiveMe.Element().On(PageKey).WithName("g515_wheel_repetition_rate").WithSize(50, 50).WithValue(0).At(327, 774).Wheel().WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMaxValue(40).Please(),
                                   GiveMe.Element().On(PageKey).WithName("g515_wheel_amplitude_measurement").WithSize(50, 50).WithValue(0).At(327, 1036).Wheel().WithImageType(ImageType.Flat).WithRotationCoefficient(20).WithMaxValue(40).Please(),
                               };
                    break;
                case RlsOncInnerRegionPage.C1_65:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                               };
                    break;
                case RlsOncInnerRegionPage.Radar:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.Element().On(PageKey).WithName("dummy_target").WithValue(70).At(239, 649).RadarTarget().Please(),
                                   GiveMe.Element().On(PageKey).WithName("dummy_noise").WithValue(70).WithStartupRotation(180).At(138, 603).RadarNoise().Please(),
                               };
                    break;
                default:
                    throw new NotSupportedException($"Unknown {nameof(PageKey)} type.");
            }
        }
    }
}