using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.DSL;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.ViewModel
{
    public class InnerPageViewModelBase : ViewModelBase
    {
        protected GiveMe GiveMe { get; }
        public InnerRegionPage PageKey { get; }

        public ObservableCollection<ElementViewModelBase> Elements
        {
            get { return GetProperty(() => Elements); }
            set { SetProperty(() => Elements, value); }
        }

        public string BackgroundSource
        {
            get { return GetProperty(() => BackgroundSource); }
            set { SetProperty(() => BackgroundSource, value); }
        }

        public InnerPageViewModelBase(InnerRegionPage pageKey, string backgroundSource)
        {
            PageKey = pageKey;
            BackgroundSource = backgroundSource;
            GiveMe = new GiveMe();
        }
    }
}