using System.Windows;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.Services.Navigate;
using Vkm.ComplexSim.ViewModel;

namespace Vkm.ComplexSim
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

            var mainPageViewModel = new MainPageViewModel();

            viewInjectionManager.Inject(Regions.OuterRegion, OuterRegionPages.MainMenu, () => mainPageViewModel, typeof(MainPage));

            NavigationFrame.NavigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            NavigationFrame.NavigationService.RemoveBackEntry(); //Отключение навигации по горячим клавишам в главном меню.
        }
    }
}
