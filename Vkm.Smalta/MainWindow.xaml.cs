using System;
using System.Collections.Generic;
using System.Windows;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Dialogs.Factories.Algorithms;
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
            var viewInjectionManager = DependencyContainer.GetViewInjectionManager();
            var actionsFactory = new ActionsFactory();

            ServiceContainer.Default.RegisterService(viewInjectionManager);
            ServiceContainer.Default.RegisterService(new HintService());
            ServiceContainer.Default.RegisterService(new LoadingService());
            ServiceContainer.Default.RegisterService(new HistoryService());
            ServiceContainer.Default.RegisterService(actionsFactory);
            ServiceContainer.Default.RegisterService(new DialogFactory());
            ServiceContainer.Default.RegisterService(new PagesFactory());

            var algorithmsFactoriesCollection = new List<AlgorithmsFactoryBase>
                                                {
                                                    new SmaltaAlgorithmsFactory(actionsFactory),
                                                    new RlsOncAlgorithmsFactory(actionsFactory)
                                                };

            var devicesFactory = new DevicesFactory(algorithmsFactoriesCollection);

            var mainPageViewModel = new MainPageViewModel(devicesFactory);

            viewInjectionManager.Inject(Regions.OuterRegion, OuterRegionPages.MainMenu, () => mainPageViewModel, typeof(MainPage));

            NavigationFrame.NavigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationFrame.NavigationService.RemoveBackEntry(); //Отключение навигации по горячим клавишам в главном меню.
        }
    }
}
