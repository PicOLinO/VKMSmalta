using System;
using System.Windows.Controls;
using System.Windows.Navigation;
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

        public void GoBack()
        {
            navigationService.GoBack();
        }
    }
}