using System.Windows;
using DevExpress.Mvvm;
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
            var viewInjectionManager = ViewInjectionManager.Default;

            viewInjectionManager.Inject(Regions.OuterRegion, OuterRegionPages.MainMenu, () => new MainPageViewModel(hintService, dialogFactory, viewInjectionManager), typeof(MainPage));
        }
    }
}
