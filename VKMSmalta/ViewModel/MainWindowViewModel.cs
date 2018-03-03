using DevExpress.Mvvm;

namespace VKMSmalta.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public bool IsLoadingSplashVisible
        {
            get { return GetProperty(() => IsLoadingSplashVisible); }
            set { SetProperty(() => IsLoadingSplashVisible, value); }
        }
    }
}