using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View;

namespace VKMSmalta.Services
{
    public class MainNavigationService 
    {
        public static MainNavigationService Instance { get; private set; }

        public static void InitializeService()
        {
            if (Instance == null)
            {
                Instance = new MainNavigationService();
            }
        }

        public void ExitDevicePage()
        {
            ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.MainMenu);
        }

        public void ExitDevicePageWithTrainingCompleteMessage()
        {
            var dialog = new TrainingCompleteDialog();
            dialog.ShowDialog();
            ExitDevicePage();
        }
    }
}