#region Usings

using System;
using System.Collections.ObjectModel;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;

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
                                   GiveMe.Element().On(PageKey).WithName("dummy_wheel").WithValue(0).At(280, 341).Wheel().WithCoefficient(20).WithMaxValue(40).Please(),
                               };
                    break;
                case RlsOncInnerRegionPage.G5_15:
                    Elements = new ObservableCollection<ElementViewModelBase>();
                    break;
                case RlsOncInnerRegionPage.C1_65:
                    Elements = new ObservableCollection<ElementViewModelBase>();
                    break;
                default:
                    throw new NotSupportedException($"Unknown {nameof(PageKey)} type.");
            }
        }
    }
}