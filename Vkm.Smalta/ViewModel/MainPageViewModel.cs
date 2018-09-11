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
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDialogFactory dialogFactory;
        private readonly IHintService hintService;
        private readonly IViewInjectionManager viewInjectionManager;
        private readonly ILoadingService loadingService;
        private readonly DevicesFactory devicesFactory;
        private readonly AlgorithmsFactory algorithmsFactory;
        private readonly ActionsFactory actionsFactory;

        public MainPageViewModel(IHintService hintService, IDialogFactory dialogFactory, IViewInjectionManager viewInjectionManager, ILoadingService loadingService,
            DevicesFactory devicesFactory, AlgorithmsFactory algorithmsFactory, ActionsFactory actionsFactory)
        {
            this.hintService = hintService;
            this.dialogFactory = dialogFactory;
            this.viewInjectionManager = viewInjectionManager;
            this.loadingService = loadingService;
            this.devicesFactory = devicesFactory;
            this.algorithmsFactory = algorithmsFactory;
            this.actionsFactory = actionsFactory;

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
        private AppGlobal App => DependencyContainer.GetApp();

        private Algorithm ChooseAlgorithm(IEnumerable<Algorithm> algorithms)
        {
            return dialogFactory.ShowChooseAlgorithmDialog(algorithms);
        }

        private DeviceEntry ChooseDevice()
        {
            return dialogFactory.ShowChooseDeviceDialog(devicesFactory, algorithmsFactory);
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
            var algorithm = ChooseAlgorithm(device.Algorithms);
            if (algorithm != null)
            {
                loadingService.LoadingOn();

                var vm = new DevicePageViewModel(startTraining ? ApplicationMode.Training : ApplicationMode.Examine, algorithm, hintService, new HistoryService(), dialogFactory, viewInjectionManager);
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
                dialogFactory.ShowLoginDialog();
            }
        }

        private void OnShowInfo()
        {
            dialogFactory.ShowInfoDialog();
        }
    }
}