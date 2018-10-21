#region Usings

using System.Collections.Generic;
using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.Services.Navigate;
using Vkm.ComplexSim.View;
using Vkm.ComplexSim.View.ViewModel;

#endregion

namespace Vkm.ComplexSim.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDevicesFactory devicesFactory;
        private readonly IDialogFactory dialogFactory;
        private readonly IHintService hintService;
        private readonly IHistoryService historyService;
        private readonly ILoadingService loadingService;
        private readonly IPagesFactory pagesFactory;
        private readonly IViewInjectionManager viewInjectionManager;

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

        public string CurrentUserName
        {
            get { return GetProperty(() => CurrentUserName); }
            set { SetProperty(() => CurrentUserName, value); }
        }

        public ICommand GoExamineCommand { get; set; }
        public ICommand GoTrainingCommand { get; set; }

        public bool IsAuthorized
        {
            get { return GetProperty(() => IsAuthorized); }
            set { SetProperty(() => IsAuthorized, value); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ShowInfoCommand { get; set; }
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

        private void GoDeviceThenGoAlgorithm(bool startTraining = false)
        {
            var device = ChooseDevice();
            if (device != null)
            {
                var algorithm = ChooseAlgorithm(device.Algorithms);
                if (algorithm != null)
                {
                    loadingService.LoadingOn();

                    var vm = new DevicePageViewModel(startTraining
                                                         ? ApplicationMode.Training
                                                         : ApplicationMode.Examine,
                                                     algorithm,
                                                     device,
                                                     hintService,
                                                     historyService,
                                                     dialogFactory,
                                                     viewInjectionManager,
                                                     pagesFactory);
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

        private void OnGoExamine()
        {
            GoDeviceThenGoAlgorithm();
        }

        private void OnGoTraining()
        {
            GoDeviceThenGoAlgorithm(true);
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

        private void UpdateLoginInfo()
        {
            IsAuthorized = App.IsAuthorized;
            if (App.CurrentUser != null)
            {
                CurrentUserName = App.CurrentUser.FullName;
            }
        }

        public void Initialize()
        {
            CreateCommands();
            UpdateLoginInfo();
        }
    }
}