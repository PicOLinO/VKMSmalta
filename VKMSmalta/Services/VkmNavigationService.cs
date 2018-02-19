using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using VKMSmalta.Dialogs;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.View;

namespace VKMSmalta.Services
{
    public class VkmNavigationService 
    {
        public static VkmNavigationService Instance { get; private set; }

        private readonly NavigationService navigationService;

        private VkmNavigationService(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public static void InitializeService(NavigationService navigationService)
        {
            if (Instance == null)
            {
                Instance = new VkmNavigationService(navigationService);
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

            navigationService.GoBack();
            return false;
        }

        public void ExitDevicePageWithTrainingCompleteMessage()
        {
            var dialog = new TrainingCompleteDialog();
            dialog.ShowDialog();
            navigationService.GoBack();
        }
    }
}