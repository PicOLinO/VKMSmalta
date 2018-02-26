using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using VKMSmalta.Dialogs;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.View;

namespace VKMSmalta.Services
{
    public class MainNavigationService 
    {
        public static MainNavigationService Instance { get; private set; }

        private readonly NavigationService navigationService;

        private MainNavigationService(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public static void InitializeService(NavigationService navigationService)
        {
            if (Instance == null)
            {
                Instance = new MainNavigationService(navigationService);
            }
        }

        public void Navigate(Page page, object viewModel)
        {
            page.DataContext = viewModel;
            navigationService.Navigate(page);
        }

        public bool ExitDevicePageWithResult(int value)
        {
            var dialog = new CheckResultsDialog(value);
            dialog.ShowDialog();

            if (((CheckResultsDialogViewModel) dialog.DataContext).IsRetry)
            {
                return true;
            }
            ExitDevicePage();
            return false;
        }

        public void ExitDevicePage()
        {
            navigationService.GoBack();
        }

        public void ExitDevicePageWithTrainingCompleteMessage()
        {
            var dialog = new TrainingCompleteDialog();
            dialog.ShowDialog();
            navigationService.GoBack();
        }
    }
}