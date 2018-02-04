using System;
using System.Windows.Navigation;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.View;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand GoExamineCommand { get; set; }
        public DelegateCommand GoTrainingCommand { get; set; }
        
        public MainPageViewModel()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            GoExamineCommand = new DelegateCommand(OnGoExamine);
            GoTrainingCommand= new DelegateCommand(OnGoTraining);
        }

        private void OnGoTraining()
        {
            VkmNavigationService.Instance.Navigate(new DevicePage(), new DevicePageViewModel(ApplicationMode.Training));
        }

        private void OnGoExamine()
        {
            VkmNavigationService.Instance.Navigate(new DevicePage(), new DevicePageViewModel(ApplicationMode.Examine));
        }
    }
}