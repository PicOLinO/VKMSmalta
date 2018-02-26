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

#endregion

namespace VKMSmalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase, IDisposable
    {
        private readonly ApplicationMode applicationMode;

        public DelegateCommand CheckResultCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoPreviousCommand { get; set; }

        private Algorithm CurrentAlgorithm { get; }

        private IEnumerable<ElementViewModelBase> UnionedElements
        {
            get
            {
                var unionedElements = new List<ElementViewModelBase>();
                foreach (var mainInnerDevicePageViewModel in pages)
                {
                    unionedElements.AddRange(mainInnerDevicePageViewModel.Elements.ToList());
                }

                return unionedElements;
            }
        }

        private ObservableCollection<InnerPageViewModelBase> pages;

        public InnerRegionPages CurrentPageKey
        {
            get { return GetProperty(() => CurrentPageKey); }
            set { SetProperty(() => CurrentPageKey, value); }
        }

        public DevicePageViewModel(ApplicationMode appMode, Algorithm algorithm)
        {
            applicationMode = appMode;

            CurrentAlgorithm = algorithm;

            InitializeServices();
            CreateCommands();

            InitializeInnerPages();

            if (applicationMode == ApplicationMode.Training)
            {
                GoTraining(CurrentAlgorithm);
            }
        }

        private void InitializeInnerPages()
        {
            var mainDevicePageVm = new MainInnerDevicePageViewModel();
            var advancedDevicePageVm = new AdvancedInnerDevicePageViewModel();

            pages = new ObservableCollection<InnerPageViewModelBase>
                    {
                        mainDevicePageVm,
                        advancedDevicePageVm
                    };

            ViewInjectionManager.Default.Inject(Regions.InnerRegion, InnerRegionPages.Main, () => mainDevicePageVm, typeof(MainInnerDevicePage));
            ViewInjectionManager.Default.Inject(Regions.InnerRegion, InnerRegionPages.Advanced, () => advancedDevicePageVm, typeof(MainInnerDevicePage));
            NavigateOnPage(InnerRegionPages.Main);
        }

        private void NavigateOnPage(InnerRegionPages page)
        {
            ViewInjectionManager.Default.Navigate(Regions.InnerRegion, page);
            CurrentPageKey = page;
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
            return CurrentPageKey != pages.Last().PageKey;
        }

        private void OnGoForward()
        {
            NavigateOnPage(InnerRegionPages.Advanced);
        }

        private bool CanGoPrevious()
        {
            return CurrentPageKey != pages.First().PageKey;
        }

        private void OnGoPrevious()
        {
            NavigateOnPage(InnerRegionPages.Main);
        }

        private void OnCheckResult()
        {
            if (applicationMode == ApplicationMode.Training)
            {
                ExitInMainMenu();
                Dispose();
                return;
            }

            var value = HistoryService.Instance.GetValueByAlgorithm(CurrentAlgorithm, UnionedElements.Cast<IValuableNamedElement>().ToList());
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

        private void InitializeServices()
        {
            HintService.InitializeService();
            HistoryService.InitializeService();
        }

        private void GoTraining(Algorithm algorithm)
        {
            foreach (var element in UnionedElements)
            {
                element.IsEnabled = false;
            }

            HintService.Instance.StartTraining(algorithm, UnionedElements.ToList());
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
            ViewInjectionManager.Default.Remove(Regions.InnerRegion, InnerRegionPages.Main);
            ViewInjectionManager.Default.Remove(Regions.InnerRegion, InnerRegionPages.Advanced);
            HintService.Instance.Reset();
            HistoryService.Instance.Reset();
        }

        public void Dispose()
        {
            ViewInjectionManager.Default.Remove(Regions.OuterRegion, OuterRegionPages.Device);
            Reset();
        }
    }
}