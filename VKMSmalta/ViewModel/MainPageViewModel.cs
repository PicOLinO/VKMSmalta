#region Usings

using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View;
using VKMSmalta.View.ViewModel;

#endregion

namespace VKMSmalta.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDialogFactory dialogFactory;
        private readonly IHintService hintService;

        public MainPageViewModel(IHintService hintService, IDialogFactory dialogFactory)
        {
            this.hintService = hintService;
            this.dialogFactory = dialogFactory;

            Initialize();
        }

        public void Initialize()
        {
            DependencyContainer.Instance.ReSetMainPageViewModel(this);
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

        private Algorithm ChooseAlgorithm()
        {
            return dialogFactory.ShowChooseAlgorithmDialog(hintService);
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
            var algorithm = ChooseAlgorithm();
            if (algorithm != null)
            {
                //TODO: Loading splash on

                var vm = new DevicePageViewModel(ApplicationMode.Examine, algorithm, hintService, new HistoryService());

                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);

                //TODO: Loading splash off
            }
        }

        private void OnGoTraining()
        {
            var algorithm = ChooseAlgorithm();
            if (algorithm != null)
            {
                //TODO: Loading splash on

                var vm = new DevicePageViewModel(ApplicationMode.Training, algorithm, hintService, new HistoryService());

                ViewInjectionManager.Default.Inject(Regions.OuterRegion, OuterRegionPages.Device, () => vm, typeof(DevicePage));
                ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.Device);

                //TODO: Loading splash off
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