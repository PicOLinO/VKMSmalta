using System;
using System.Windows.Navigation;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand GoExamineCommand { get; set; }
        public DelegateCommand GoTrainingCommand { get; set; }
        
        public MainPageViewModel()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            LoginCommand = new DelegateCommand(OnLogin);
            GoExamineCommand = new DelegateCommand(OnGoExamine);
            GoTrainingCommand= new DelegateCommand(OnGoTraining);
        }

        private void OnLogin()
        {
            var loginDialog = new LoginDialog();
            loginDialog.ShowDialog(); //TODO:
        }

        private void OnGoTraining()
        {
            var algorithm = ChooseAlgorithm();
            if (algorithm != null)
            {
                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => new DevicePageViewModel(ApplicationMode.Training, algorithm), typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);
            }
        }

        private void OnGoExamine()
        {
            var algorithm = ChooseAlgorithm();
            if (algorithm != null)
            {
                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => new DevicePageViewModel(ApplicationMode.Examine, algorithm), typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);
            }
        }

        private Algorithm ChooseAlgorithm()
        {
            var chooseDialog = new ChooseAlgorithmDialog();
            chooseDialog.ShowDialog();
            return chooseDialog.SelectedAlgorithm;
        }
    }
}