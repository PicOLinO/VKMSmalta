using System;
using System.Windows.Navigation;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Dialogs.ViewModel;
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
            var hintService = new HintService();
            var algorithm = ChooseAlgorithm(hintService);
            if (algorithm != null)
            {
                var vm = new DevicePageViewModel(ApplicationMode.Training, algorithm, hintService, new HistoryService());

                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);
            }
        }

        private void OnGoExamine()
        {
            var hintService = new HintService();
            var algorithm = ChooseAlgorithm(hintService);
            if (algorithm != null)
            {
                var vm = new DevicePageViewModel(ApplicationMode.Examine, algorithm, hintService, new HistoryService());

                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);
            }
        }

        private Algorithm ChooseAlgorithm(HintService hintService)
        {
            var chooseDialog = new ChooseAlgorithmDialog(new ChooseAlgorithmDialogViewModel(hintService));
            chooseDialog.ShowDialog();
            return chooseDialog.SelectedAlgorithm;
        }
    }
}