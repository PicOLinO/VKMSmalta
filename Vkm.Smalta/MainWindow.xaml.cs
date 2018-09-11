using System;
using System.Windows;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.ViewModel;

namespace Vkm.Smalta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel();
            DataContext = vm;

            InitializeMainPageViewModel();
        }

        private void InitializeMainPageViewModel()
        {
            var dialogFactory = DependencyContainer.GetDialogFactory();
            var hintService = new HintService();
            var viewInjectionManager = DependencyContainer.GetViewInjectionManager();
            var loadingService = new LoadingService();
            var actionsFactory = new ActionsFactory(hintService);
            var algorithmsFactory = new AlgorithmsFactory(actionsFactory);
            var historyService = new HistoryService();
            var devicesFactory = new DevicesFactory(algorithmsFactory, historyService);
            var pagesFactory = new PagesFactory(historyService);

            var mainPageViewModel = new MainPageViewModel(hintService, dialogFactory, viewInjectionManager, loadingService, devicesFactory, historyService, pagesFactory);

            viewInjectionManager.Inject(Regions.OuterRegion, OuterRegionPages.MainMenu, () => mainPageViewModel, typeof(MainPage));

            NavigationFrame.NavigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationFrame.NavigationService.RemoveBackEntry(); //Отключение навигации по горячим клавишам в главном меню.
        }
    }
}
