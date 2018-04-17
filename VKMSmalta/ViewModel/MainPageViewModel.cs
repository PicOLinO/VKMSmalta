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
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand GoExamineCommand { get; set; }
        public DelegateCommand GoTrainingCommand { get; set; }
        public DelegateCommand ShowInfoCommand { get; set; }


        public MainPageViewModel()
        {
            DependencyContainer.Instance.ReSetMainPageViewModel(this);
            CreateCommands();
        }

        private void CreateCommands()
        {
            LoginCommand = new DelegateCommand(OnLogin);
            GoExamineCommand = new DelegateCommand(OnGoExamine);
            GoTrainingCommand = new DelegateCommand(OnGoTraining);
            RegisterCommand = new DelegateCommand(OnRegister);
            ShowInfoCommand = new DelegateCommand(OnShowInfo);
        }

        private void OnShowInfo()
        {
            var infoText = "some text";
            var infoDialog = new InfoDialog(infoText);
            infoDialog.ShowDialog();
        }

        private void OnLogin()
        {
            var authorizationUri = DependencyContainer.Instance.Config.AdminUri.AdminAuthorizeUri;
            var loginDialog = new LoginDialog(authorizationUri);
            loginDialog.ShowDialog();
        }

        private void OnRegister()
        {
            var registerUri = DependencyContainer.Instance.Config.AdminUri.AdminRegisterUri;
            var registerDialog = new RegisterDialog(registerUri);
            registerDialog.ShowDialog();
        }

        private void OnGoTraining()
        {
            var hintService = new HintService();
            var algorithm = ChooseAlgorithm(hintService);
            if (algorithm != null)
            {
                DependencyContainer.Instance.SetLoadingSplash(true);

                var vm = new DevicePageViewModel(ApplicationMode.Training, algorithm, hintService, new HistoryService());

                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);

                DependencyContainer.Instance.SetLoadingSplash(false);
            }
        }

        private void OnGoExamine()
        {
            var hintService = new HintService();
            var algorithm = ChooseAlgorithm(hintService);
            if (algorithm != null)
            {
                DependencyContainer.Instance.SetLoadingSplash(true);

                var vm = new DevicePageViewModel(ApplicationMode.Examine, algorithm, hintService, new HistoryService());

                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);

                DependencyContainer.Instance.SetLoadingSplash(false);
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