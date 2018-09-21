#region Usings

using System.Collections.Generic;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.ViewModel
{t
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDialogFactory dialogFactory;
        private readonly IHintService hintService;
        private readonly IViewInjectionManager viewInjectionManager;
        private readonly ILoadingService loadingService;
        private readonly IDevicesFactory devicesFactory;
        private readonly IHistoryService historyService;
        private readonly IPagesFactory pagesFactory;

        public MainPageViewModel()
        {
            hintService = ServiceContainer.GetService<IHintService>();
            dialogFactory = ServiceContainer.GetService<IDialogFactory>();
            viewInjectionManager = ServiceContainer.GetService<IViewInjectionManager>();
            loadingService = ServiceContainer.GetService<ILoadingService>();
            historyService = ServiceContainer.GetService<IHistoryService>();
            pagesFactory = ServiceContainer.GetService<IPagesFactory>();
            devicesFactory = ServiceContainer.GetService<IDevicesFactory>();

            Initialize();
        }

        public void Initialize()
        {
            CreateCommands();
            UpdateLoginInfo();
        }

        private void UpdateLoginInfo()
        {
            IsAuthorized = App.IsAuthorized;
            if (App.CurrentUser != null)
            {
                CurrentUserName = App.CurrentUser.FullName;
            }
        }

        public string CurrentUserName
        {
            get { return GetProperty(() => CurrentUserName); }
            set { SetProperty(() => CurrentUserName, value); }
        }

        public DelegateCommand GoExamineCommand { get; set; }
        public DelegateCommand GoTrainingCommand { get; set; }

        public bool IsAuthorized
        {
            get { return GetProperty(() => IsAuthorized); }
            set { SetProperty(() => IsAuthorized, value); }
        }

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand ShowInfoCommand { get; set; }
        private IAppContext App => DependencyContainer.GetApp();

        private Algorithm ChooseAlgorithm(IEnumerable<Algorithm> algorithms)
        {
            return dialogFactory.ShowChooseAlgorithmDialog(algorithms);
        }

        private DeviceEntry ChooseDevice()
        {
            return dialogFactory.ShowChooseDeviceDialog(devicesFactory);
        }

        private void CreateCommands()
        {
            LoginCommand = new DelegateCommand(OnLogin);
            GoExamineCommand = new DelegateCommand(OnGoExamine);
            GoTrainingCommand = new DelegateCommand(OnGoTraining);
            RegisterCommand = new DelegateCommand(OnRegister);
            ShowInfoCommand = new DelegateCommand(OnShowInfo);
        }

        private void OnGoExamine()
        {
            GoAlgorithm();
        }

        private void OnGoTraining()
        {
            GoAlgorithm(true);
        }

        private void GoAlgorithm(bool startTraining = false)
        {
            var device = ChooseDevice();
            if (device != null)
            {
                var algorithm = ChooseAlgorithm(device.Algorithms);
                if (algorithm != null)
                {
                    loadingService.LoadingOn();

                    var vm = new DevicePageViewModel(startTraining ? ApplicationMode.Training : ApplicationMode.Examine, algorithm, device, hintService, historyService, dialogFactory, viewInjectionManager, pagesFactory);
                    CurrentDevicePageService.Initialize(vm);
                    if (startTraining)
                    {
                        vm.LaunchTraining();
                    }

                    viewInjectionManager.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                    viewInjectionManager.Navigate(Regions.OuterRegion, OuterRegionPages.Device);

                    loadingService.LoadingOff();
                }
            }
        }

        private void OnLogin()
        {
            dialogFactory.ShowLoginDialog();
            UpdateLoginInfo();
        }

        private void OnRegister()
        {
            var success = dialogFactory.ShowRegisterDialog();
            if (success)
            {
                OnLogin();
            }
        }

        private void OnShowInfo()
        {
            dialogFactory.ShowInfoDialog();
        }
    }
}