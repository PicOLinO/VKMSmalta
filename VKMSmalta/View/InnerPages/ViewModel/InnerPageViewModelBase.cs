using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.InnerPages.ViewModel
{
    public class InnerPageViewModelBase : ViewModelBase
    {
        public InnerRegionPages PageKey { get; }

        public ObservableCollection<ElementViewModelBase> Elements
        {
            get { return GetProperty(() => Elements); }
            set { SetProperty(() => Elements, value); }
        }

        public ImageSource BackgroundSource
        {
            get { return GetProperty(() => BackgroundSource); }
            set { SetProperty(() => BackgroundSource, value); }
        }

        public InnerPageViewModelBase(InnerRegionPages pageKey, string backgroundSource)
        {
            PageKey = pageKey;
            BackgroundSource = new BitmapImage(new Uri(backgroundSource, UriKind.RelativeOrAbsolute));
        }
    }
}