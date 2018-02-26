using System;
using System.Windows.Navigation;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Domain;
using VKMSmalta.Services;
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
                MainNavigationService.Instance.Navigate(new DevicePage(), new DevicePageViewModel(ApplicationMode.Training, algorithm));
            }
        }

        private void OnGoExamine()
        {
            var algorithm = ChooseAlgorithm();
            if (algorithm != null)
            {
                MainNavigationService.Instance.Navigate(new DevicePage(), new DevicePageViewModel(ApplicationMode.Examine, algorithm));
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