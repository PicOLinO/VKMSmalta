#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Dialogs.ViewModel;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.Services.Navigate;
using Vkm.Smalta.View.Elements.ViewModel;
using Vkm.Smalta.View.Elements.ViewModel.Interfaces;
using Vkm.Smalta.View.InnerPages;
using Vkm.Smalta.View.InnerPages.ViewModel;

#endregion

namespace Vkm.Smalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase, IDisposable
    {
        public ObservableCollection<InnerPageViewModelBase> Pages;
        public ApplicationMode Mode { get; private set; }
        private readonly IHintService hintService;
        private readonly HistoryService historyService;
        private readonly IDialogFactory dialogFactory;
        private readonly IViewInjectionManager viewInjectionManager;

        public DevicePageViewModel(ApplicationMode appMode, 
                                   Algorithm algorithm, 
                                   IHintService hintService, 
                                   HistoryService historyService, 
                                   IDialogFactory dialogFactory, 
                                   IViewInjectionManager viewInjectionManager)
        {
            Mode = appMode;
            CurrentAlgorithm = algorithm;
            this.hintService = hintService;
            this.historyService = historyService;
            this.dialogFactory = dialogFactory;
            this.viewInjectionManager = viewInjectionManager;

            Initialize();
        }

        public AsyncCommand CheckResultCommand { get; set; }

        public InnerRegionPage CurrentPageKey
        {
            get { return GetProperty(() => CurrentPageKey); }
            private set { SetProperty(() => CurrentPageKey, value, OnCurrentPageKeyChanged); }
        }

        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoPreviousCommand { get; set; }

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

        public InnerRegionPage NextPageKey
        {
            get { return GetProperty(() => NextPageKey); }
            set { SetProperty(() => NextPageKey, value); }
        }

        public InnerRegionPage PreviousPageKey
        {
            get { return GetProperty(() => PreviousPageKey); }
            set { SetProperty(() => PreviousPageKey, value); }
        }

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

        private Algorithm CurrentAlgorithm { get; }

        private int CurrentPageIndex => Pages.IndexOf(Pages.Single(p => p.PageKey == CurrentPageKey));

        private bool CanGoForward()
        {
            return CurrentPageKey != Pages.Last().PageKey;
        }

        private bool CanGoPrevious()
        {
            return CurrentPageKey != Pages.First().PageKey;
        }

        public void Initialize()
        {
            CreateCommands();
            InitializeInnerPages();
        }

        private bool CheckResults(int value)
        {
            var dialog = new CheckResultsDialog(value);
            dialog.ShowDialog();

            if (((CheckResultsDialogViewModel) dialog.DataContext).IsRetry)
            {
                return true;
            }

            return false;
        }

        private void CreateCommands()
        {
            GoForwardCommand = new DelegateCommand(OnGoForward, CanGoForward);
            CheckResultCommand = new AsyncCommand(OnCheckResult);
            GoPreviousCommand = new DelegateCommand(OnGoPrevious, CanGoPrevious);
        }

        public void EndTraining()
        {
            var goExamine = dialogFactory.ShowTrainingCompleteDialog();
            if (goExamine)
            {
                Mode = ApplicationMode.Examine;
                Reset();
                InitializeInnerPages();
            }
            else
            {
                Dispose();
                ExitInMainMenu();
            }
        }

        private void ExitInMainMenu()
        {
            viewInjectionManager.Navigate(Regions.OuterRegion, OuterRegionPages.MainMenu);
        }

        public void LaunchTraining()
        {
            GoTraining(CurrentAlgorithm);
        }

        private void GoTraining(Algorithm algorithm)
        {
            foreach (var element in UnionedElements)
            {
                element.IsEnabled = false;
            }

            hintService.StartTraining(algorithm, UnionedElements.ToList(), EndTraining);
        }

        private void InitializeInnerPages()
        {
            Pages = new ObservableCollection<InnerPageViewModelBase>
                    {
                        new MainInnerDevicePageViewModel(historyService, InnerRegionPage.LO01I_LO01K, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01I_LO01K.png", CurrentAlgorithm),
                        new MainInnerDevicePageViewModel(historyService, InnerRegionPage.LO01P, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01P.png", CurrentAlgorithm),
                        new MainInnerDevicePageViewModel(historyService, InnerRegionPage.LO01R, "/Vkm.Smalta;component/View/Images/Backgrounds/LO01R.png", CurrentAlgorithm)
                    };

            foreach (var page in Pages)
            {
                viewInjectionManager.Inject(Regions.InnerRegion, page.PageKey, () => page, typeof(MainInnerDevicePage));
            }

            NavigateOnPage(InnerRegionPage.LO01P);
        }

        private void NavigateOnPage(InnerRegionPage page)
        {
            viewInjectionManager.Navigate(Regions.InnerRegion, page);
            CurrentPageKey = page;
            hintService.OnNavigated(page);
        }

        private async Task OnCheckResult()
        {
            if (Mode == ApplicationMode.Training)
            {
                ExitInMainMenu();
                Dispose();
                return;
            }

            var isContinue = DialogFactory.AskYesNo("Завершить выполнение экзамена?\nВаш результат сразу же будет отправлен преподавателю");
            if (!isContinue)
            {
                return;
            }

            var value = historyService.GetValueByAlgorithmByUserActions(CurrentAlgorithm, UnionedElements.Cast<IValuableNamedElement>().ToList());

            var examineResult = new ExamineResult
                                {
                                    Date = DateTime.Now,
                                    AlgorithmName = CurrentAlgorithm.Name,
                                    Value = value
                                };
            try
            {
                await NetworkService.Instance.SendExamineResultToAdmin(examineResult);
            }
            catch (Exception e)
            {
                DialogFactory.ShowErrorMessage(e);
            }

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

        private void OnCurrentPageKeyChanged()
        {
            NextPageKey = CanGoForward()
                              ? Pages[CurrentPageIndex + 1].PageKey
                              : InnerRegionPage.Empty;
            PreviousPageKey = CanGoPrevious()
                                  ? Pages[CurrentPageIndex - 1].PageKey
                                  : InnerRegionPage.Empty;
        }

        private void OnGoForward()
        {
            NavigateOnPage(NextPageKey);
        }

        private void OnGoPrevious()
        {
            NavigateOnPage(PreviousPageKey);
        }

        private void Reset()
        {
            foreach (var element in UnionedElements)
            {
                if (element is IDependencyActivatorElement activatorElement)
                {
                    activatorElement.CancelDependencyActionsExecution();
                }
            }

            //Remove Views Injections
            foreach (var page in Pages)
            {
                viewInjectionManager.Remove(Regions.InnerRegion, page.PageKey);
            }

            //Reset services
            hintService.Reset();
            historyService.Reset();
        }

        #region IDisposable

        public void Dispose()
        {
            viewInjectionManager.Remove(Regions.OuterRegion, OuterRegionPages.Device);
            Reset();
        }

        #endregion
    }
}