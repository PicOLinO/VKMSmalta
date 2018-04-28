using System;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace VKMSmalta.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public bool IsLoadingSplashVisible
        {
            get { return GetProperty(() => IsLoadingSplashVisible); }
            set { SetProperty(() => IsLoadingSplashVisible, value, OnIsLoadingSplashVisibleChanged); }
        }

        private void OnIsLoadingSplashVisibleChanged()
        {
            Mouse.OverrideCursor = IsLoadingSplashVisible
                                       ? Cursors.Wait
                                       : null;
        }
    }
}