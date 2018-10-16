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
                                   GiveMe.Element().On(PageKey).WithName("dummy_numberdisplay").WithValue(10).At(246, 704).NumberDisplay().Please()
                               };
                    break;
                case RlsOncInnerRegionPage.C1_65:
                    Elements = new ObservableCollection<ElementViewModelBase>();
                    break;
                case RlsOncInnerRegionPage.Radar:
                    Elements = new ObservableCollection<ElementViewModelBase>
                               {
                                   GiveMe.Element().On(PageKey).WithName("dummy_target").WithValue(70).At(239, 649).RadarTarget().Please(),
                                   GiveMe.Element().On(PageKey).WithName("dummy_noise").WithValue(70).WithStartupRotation(45).At(138, 603).RadarNoise().Please(),
                               };
                    break;
                default:
                    throw new NotSupportedException($"Unknown {nameof(PageKey)} type.");
            }
        }
    }
}