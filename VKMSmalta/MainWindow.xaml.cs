using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.ViewModel;

namespace VKMSmalta
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

            InitializeVmInDependencyContainer(vm);
            InitializeMainPageViewModel();
        }

        private void InitializeMainPageViewModel()
        {
            var dialogFactory = DependencyContainer.GetDialogFactory();
            var hintService = new HintService();

            ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.MainMenu, () => new MainPageViewModel(hintService, dialogFactory), typeof(MainPage));
        }

        private void InitializeVmInDependencyContainer(MainWindowViewModel vm)
        {
        }
    }
}
