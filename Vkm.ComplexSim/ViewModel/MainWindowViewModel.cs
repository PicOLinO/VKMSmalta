#region Usings

using System.Windows.Input;
using DevExpress.Mvvm;

#endregion

namespace Vkm.ComplexSim.ViewModel
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