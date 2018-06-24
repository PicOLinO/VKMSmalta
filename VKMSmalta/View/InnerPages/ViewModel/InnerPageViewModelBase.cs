#region Usings

using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.DSL;

#endregion

namespace VKMSmalta.View.InnerPages.ViewModel
{
    public class InnerPageViewModelBase : ViewModelBase
    {
        protected InnerPageViewModelBase(InnerRegionPage pageKey, string backgroundSource)
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

        public InnerRegionPage PageKey { get; }
        protected GiveMe GiveMe { get; }
    }
}