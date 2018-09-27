#region Usings

using System;
using Vkm.Smalta.Domain;

#endregion

namespace Vkm.Smalta.View.InnerPages.ViewModel
{
    public abstract class MainInnerDevicePageViewModel : InnerPageViewModelBase
    {
        protected readonly Algorithm CurrentAlgorithm;

        public MainInnerDevicePageViewModel(Enum pageKey, string background, Algorithm currentAlgorithm) : base(pageKey, background)
        {
            CurrentAlgorithm = currentAlgorithm;
        }

        protected virtual void InitializeElements()
        {
        }
    }
}