#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.InnerPages.ViewModel;
using Action = System.Action;

#endregion

namespace VKMSmalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase, IDisposable
    {
        private readonly ApplicationMode applicationMode;
        private readonly HintService hintService;
        private readonly HistoryService historyService;

        public DelegateCommand CheckResultCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoPreviousCommand { get; set; }

        private Algorithm CurrentAlgorithm { get; }

        public IEnumerable<ElementViewModelBase> UnionedElements
        {
            get
            {
                var unionedElements = new List<ElementViewModelBase>();

                foreach (var mainInnerDevicePageViewModel in Pages)
                {
                    unionedElements.AddRange(mainInnerDevicePageViewModel.Elements.ToList());
                }

                return unionedElements;
            }
        }

        public ObservableCollection<InnerPageViewModelBase> Pages;

        public InnerRegionPages CurrentPageKey
        {
            get { return GetProperty(() => CurrentPageKey); }
            set { SetProperty(() => CurrentPageKey, value); }
        }

        public bool IsGoForwardHintOpen
        {
            get { return GetProperty(() => IsGoForwardHintOpen); }
            set { SetProperty(() => IsGoForwardHintOpen, value); }
        }

        public bool IsGoPreviousHintOpen
        {
            get { return GetProperty(() => IsGoPreviousHintOpen); }
            set { SetProperty(() => IsGoPreviousHintOpen, value); }
        }

        public DevicePageViewModel(ApplicationMode appMode, Algorithm algorithm, HintService hintService, HistoryService historyService)
        {
            applicationMode = appMode;
            CurrentAlgorithm = algorithm;
            this.hintService = hintService;
            this.historyService = historyService;

            DependencyContainer.Instance.ReSetDevicePageViewModel(this);
            CreateCommands();

            InitializeInnerPages();

            if (applicationMode == ApplicationMode.Training)
            {
                GoTraining(CurrentAlgorithm);
            }
        }

        private void InitializeInnerPages()
        {
            var mainDevicePageVm = new MainInnerDevicePageViewModel(historyService);
            var advancedDevicePageVm = new AdvancedInnerDevicePageViewModel(historyService);

            Pages = new ObservableCollection<InnerPageViewModelBase>
                    {
                        mainDevicePageVm,
                        advancedDevicePageVm
                    };

            ViewInjectionManager.Default.Inject(Regions.InnerRegion, InnerRegionPages.L001P, () => mainDevicePageVm, typeof(MainInnerDevicePage));
            ViewInjectionManager.Default.Inject(Regions.InnerRegion, InnerRegionPages.L001R, () => advancedDevicePageVm, typeof(MainInnerDevicePage));

            NavigateOnPage(InnerRegionPages.L001P);
        }

        private void NavigateOnPage(InnerRegionPages page)
        {
            ViewInjectionManager.Default.Navigate(Regions.InnerRegion, page);
            CurrentPageKey = page;
            hintService.OnNavigated(page);
        }

        #region Commands

        private void CreateCommands()
        {
            GoForwardCommand = new DelegateCommand(OnGoForward, CanGoForward);
            CheckResultCommand = new DelegateCommand(OnCheckResult);
            GoPreviousCommand = new DelegateCommand(OnGoPrevious, CanGoPrevious);
        }

        private bool CanGoForward()
        {
            return CurrentPageKey != Pages.Last().PageKey;
        }

        private void OnGoForward()
        {
            NavigateOnPage(InnerRegionPages.L001R);
        }

        private bool CanGoPrevious()
        {
            return CurrentPageKey != Pages.First().PageKey;
        }

        private void OnGoPrevious()
        {
            NavigateOnPage(InnerRegionPages.L001P);
        }

        private void OnCheckResult()
        {
            if (applicationMode == ApplicationMode.Training)
            {
                ExitInMainMenu();
                Dispose();
                return;
            }

            var value = historyService.GetValueByAlgorithm(CurrentAlgorithm, UnionedElements.Cast<IValuableNamedElement>().ToList());
            var retry = CheckResults(value);
            
            if (retry)
            {
                Reset();
                InitializeInnerPages();
            }
            else
            {
                Dispose();
                ExitInMainMenu();
            }
        }

        #endregion

        private void GoTraining(Algorithm algorithm)
        {
            foreach (var element in UnionedElements)
            {
                element.IsEnabled = false;
            }

            hintService.StartTraining(algorithm, UnionedElements.ToList(), EndTraining);
        }

        private void EndTraining()
        {
            var dialog = new TrainingCompleteDialog();
            dialog.ShowDialog();
            Dispose();
            ExitInMainMenu();
        }

        private bool CheckResults(int value)
        {
            var dialog = new CheckResultsDialog(value);
            dialog.ShowDialog();

            if (((CheckResultsDialogViewModel)dialog.DataContext).IsRetry)
            {
                return true;
            }

            return false;
        }

        private void ExitInMainMenu()
        {
            ViewInjectionManager.Default.Navigate(Regions.OuterRegion, OuterRegionPages.MainMenu);
        }

        private void Reset()
        {
            //Remove Views Injections
            ViewInjectionManager.Default.Remove(Regions.InnerRegion, InnerRegionPages.L001P);
            ViewInjectionManager.Default.Remove(Regions.InnerRegion, InnerRegionPages.L001R);

            //Reset services
            hintService.Reset();
            historyService.Reset();
        }

        public void Dispose()
        {
            ViewInjectionManager.Default.Remove(Regions.OuterRegion, OuterRegionPages.Device);
            Reset();
        }
    }
}