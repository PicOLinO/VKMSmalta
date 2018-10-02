#region Usings

using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Images;
using Vkm.Smalta.View.InnerPages.DSL;

#endregion

namespace Vkm.Smalta.View.InnerPages.ViewModel
{
    public class InnerPageViewModelBase : ViewModelBase
    {
        protected InnerPageViewModelBase(Enum pageKey, string backgroundSource)
        {
            PageKey = pageKey;
            BackgroundSource = backgroundSource;
            GiveMe = new GiveMe();
        }

        public string BackgroundSource
        {
            get { return GetProperty(() => BackgroundSource); }
            set { SetProperty(() => BackgroundSource, value); }
        }

        public ObservableCollection<ElementViewModelBase> Elements
        {
            get { return GetProperty(() => Elements); }
            set { SetProperty(() => Elements, value); }
        }

        public Enum PageKey { get; }
        protected GiveMe GiveMe { get; }
    }
}