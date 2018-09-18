#region Usings

using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;

#endregion

namespace Vkm.Smalta.View.InnerPages.ViewModel
{
    public class RlsOncInnerDevicePageViewModel : MainInnerDevicePageViewModel
    {
        public RlsOncInnerDevicePageViewModel(HistoryService historyService, Enum pageKey, string background, Algorithm currentAlgorithm) : base(historyService, pageKey, background, currentAlgorithm)
        {
            InitializeElements();
        }

        protected sealed override void InitializeElements()
        {
            //TODO: RlsOncInnerRegionPage
            switch (PageKey)
            {
            }
        }
    }
}