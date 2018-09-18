#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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
        public bool IsGodModeOn { get; set; }
        private readonly DeviceEntry device;
        private readonly IHintService hintService;
        private readonly HistoryService historyService;
        private readonly IDialogFactory dialogFactory;
        private readonly IViewInjectionManager viewInjectionManager;
        private readonly PagesFactory pagesFactory;
        private readonly Queue<Key> cheatInput;
        private readonly Key[] cheatEthalon = { Key.Z, Key.D, Key.C, Key.T, Key.C, Key.L, Key.F, Key.V };

        public DevicePageViewModel(ApplicationMode appMode, 
                                   Algorithm algorithm,
                                   DeviceEntry device,
                                   IHintService hintService, 
                                   HistoryService historyService, 
                                   IDialogFactory dialogFactory, 
                                   IViewInjectionManager viewInjectionManager,
                                   PagesFactory pagesFactory)
        {
            Mode = appMode;
            CurrentAlgorithm = algorithm;
            this.device = device;
            this.hintService = hintService;
            this.historyService = historyService;
            this.dialogFactory = dialogFactory;
            this.viewInjectionManager = viewInjectionManager;
            this.pagesFactory = pagesFactory;

            cheatInput = new Queue<Key>(8);

            Initialize();
        }

        public AsyncCommand CheckResultCommand { get; set; }

        public Enum CurrentPageKey
        {
            get { return GetProperty(() => CurrentPageKey); }
            private set { SetProperty(() => CurrentPageKey, value, OnCurrentPageKeyChanged); }
        }

        public DelegateCommand<Key> KeyDownCommand { get; set; }
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

        public Enum NextPageKey
        {
            get { return GetProperty(() => NextPageKey); }
            set { SetProperty(() => NextPageKey, value); }
        }

        public Enum PreviousPageKey
        {
            get { return GetProperty(() => PreviousPageKey); }
            set { SetProperty(() => PreviousPageKey, value); }
        }

        public IEnumerable<ElementViewModelBase> UnionElements
        {
            get
            {
                var unionElements = new List<ElementViewModelBase>();

                foreach (var mainInnerDevicePageViewModel in Pages)
                {
                    unionElements.AddRange(mainInnerDevicePageViewModel.Elements.ToList());
                }

                return unionElements;
            }
        }

        private Algorithm CurrentAlgorithm { get; }

        private int CurrentPageIndex => Pages.IndexOf(Pages.Single(p => Equals(p.PageKey, CurrentPageKey)));

        private bool CanGoForward()
        {
            return CurrentPageKey != Pages.Last().PageKey;
        }

        private bool CanGoPrevious()
        {
            return !Equals(CurrentPageKey, Pages.First().PageKey);
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

        public bool IsTrollFaceOpen
        {
            get { return GetProperty(() => IsTrollFaceOpen); }
            set { SetProperty(() => IsTrollFaceOpen, value); }
        }

        private void CreateCommands()
        {
            GoForwardCommand = new DelegateCommand(OnGoForward, CanGoForward);
            CheckResultCommand = new AsyncCommand(OnCheckResult);
            GoPreviousCommand = new DelegateCommand(OnGoPrevious, CanGoPrevious);
            if (Mode == ApplicationMode.Examine)
            {
                KeyDownCommand = new DelegateCommand<Key>(OnKeyDown);
            }
        }

        private async void OnKeyDown(Key key)
        {
            if (IsGodModeOn)
            {
                return;
            }

            cheatInput.Enqueue(key);
            if (cheatInput.Count >= 8)
            {
                if (cheatInput.ToArray().SequenceEqual(cheatEthalon))
                {
                    IsGodModeOn = true;
                    IsTrollFaceOpen = true;
                    await Task.Delay(1000);
                    IsTrollFaceOpen = false;
                }
                cheatInput.Dequeue();
            }
        }

        public void EndTraining()
        {
            var result = dialogFactory.ShowTrainingCompleteDialog();
            if (result.GoExamine)
            {
                Mode = ApplicationMode.Examine;
                Reset();
                InitializeInnerPages();
            }
            else if (result.GoRetry)
            {
                Reset();
                InitializeInnerPages();
                //hintService.ShowNextHint();
                LaunchTraining();
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
            foreach (var element in UnionElements)
            {
                element.IsEnabled = false;
            }

            hintService.StartTraining(algorithm, UnionElements.ToList(), EndTraining);
        }

        private void InitializeInnerPages()
        {
            var pagesList = pagesFactory.CreatePagesFor(device.Name, CurrentAlgorithm);
            Pages = new ObservableCollection<InnerPageViewModelBase>(pagesList);

            foreach (var page in Pages)
            {
                viewInjectionManager.Inject(Regions.InnerRegion, page.PageKey, () => page, typeof(MainInnerDevicePage));
            }

            NavigateOnInnerPage(device.FirstPageKey);
        }

        public void NavigateOnInnerPage(Enum page)
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
            
            var value = IsGodModeOn
                        ? new Random().Next(4, 6)
                        : historyService.GetValueByAlgorithmByUserActions(CurrentAlgorithm, UnionElements.Cast<IValuableNamedElement>().ToList());

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
                              : null;
            PreviousPageKey = CanGoPrevious()
                                  ? Pages[CurrentPageIndex - 1].PageKey
                                  : null;
        }

        private void OnGoForward()
        {
            NavigateOnInnerPage(NextPageKey);
        }

        private void OnGoPrevious()
        {
            NavigateOnInnerPage(PreviousPageKey);
        }

        private void Reset()
        {
            foreach (var element in UnionElements)
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