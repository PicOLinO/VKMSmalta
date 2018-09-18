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
    public abstract class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        protected readonly Algorithm CurrentAlgorithm;
        protected readonly HistoryService HistoryService;

        public MainInnerDevicePageViewModel(HistoryService historyService, Enum pageKey, string background, Algorithm currentAlgorithm) : base(pageKey, background)
        {
            HistoryService = historyService;
            CurrentAlgorithm = currentAlgorithm;
        }

        protected virtual void InitializeElements()
        {
        }
    }
}