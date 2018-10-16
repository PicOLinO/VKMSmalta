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
                                   GiveMe.Element().On(PageKey).WithName("dummy_wheel").WithValue(0).At(280, 341).Wheel().WithImageType(ImageType.Point).WithCoefficient(20).WithMaxValue(40).Please(),
                               };
                    break;
                case RlsOncInnerRegionPage.G5_15:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.Element().On(PageKey).WithName("dummy_numberdisplay1").WithValue(180).At(246, 446).NumberDisplay().Please(),
                                   GiveMe.Element().On(PageKey).WithName("dummy_numberdisplay2").WithValue(180).At(246, 704).NumberDisplay().Please(),
                                   GiveMe.Element().On(PageKey).WithName("dummy_numberdisplay3").WithValue(180).At(246, 953).NumberDisplay().Please(),

                                   GiveMe.Element().On(PageKey).WithName("first_stepwheel_1").WithValue(0).At(91, 387).WithStartupRotation(60).RotateStepWheel().WithRotationStepDegrees(60).WithMaxValue(3).Please(),
                                   GiveMe.Element().On(PageKey).WithName("first_stepwheel_2").WithValue(0).At(98, 905).WithStartupRotation(-50).RotateStepWheel().WithRotationStepDegrees(31).WithMaxValue(10).Please(),


                                   GiveMe.Element().On(PageKey).WithName("dummy_wheel1").WithValue(0).At(327, 513).Wheel().WithImageType(ImageType.Flat).WithCoefficient(20).WithMaxValue(40).Please(),
                                   GiveMe.Element().On(PageKey).WithName("dummy_wheel2").WithValue(0).At(327, 774).Wheel().WithImageType(ImageType.Flat).WithCoefficient(20).WithMaxValue(40).Please(),
                                   GiveMe.Element().On(PageKey).WithName("dummy_wheel3").WithValue(0).At(327, 1036).Wheel().WithImageType(ImageType.Flat).WithCoefficient(20).WithMaxValue(40).Please(),
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