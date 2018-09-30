#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.Factories;
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
        private readonly Key[] cheatEthalon = {Key.Z, Key.D, Key.C, Key.T, Key.C, Key.L, Key.F, Key.V};
        private readonly Queue<Key> cheatInput;
        private readonly DeviceEntry device;
        private readonly IDialogFactory dialogFactory;
        private readonly IHintService hintService;
        private readonly IHistoryService historyService;
        private readonly IPagesFactory pagesFactory;
        private readonly IViewInjectionManager viewInjectionManager;

        public DevicePageViewModel(ApplicationMode appMode,
                                   Algorithm algorithm,
                                   DeviceEntry device,
                                   IHintService hintService,
                                   IHistoryService historyService,
                                   IDialogFactory dialogFactory,
                                   IViewInjectionManager viewInjectionManager,
                                   IPagesFactory pagesFactory)
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

        public ICommand GoForwardCommand { get; set; }
        public ICommand GoPreviousCommand { get; set; }
        public bool IsGodModeOn { get; set; }

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

        public bool IsTrollFaceOpen
        {
            get { return GetProperty(() => IsTrollFaceOpen); }
            set { SetProperty(() => IsTrollFaceOpen, value); }
        }

        public ICommand<Key> KeyDownCommand { get; set; }
        public ApplicationMode Mode { get; private set; }

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
            return !Equals(CurrentPageKey, Pages.Last().PageKey);
        }

        private bool CanGoPrevious()
        {
            return !Equals(CurrentPageKey, Pages.First().PageKey);
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

        private void ExitInMainMenu()
        {
            viewInjectionManager.Navigate(Regions.OuterRegion, OuterRegionPages.MainMenu);
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

        private async Task OnCheckResult()
        {
            if (Mode == ApplicationMode.Training)
            {
                ExitInMainMenu();
                Dispose();
                return;
            }

            var isContinue = dialogFactory.AskYesNo("Завершить выполнение экзамена?\nВаш результат сразу же будет отправлен преподавателю");
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
                var networkService = GetService<INetworkService>();
                await networkService.SendExamineResultToAdmin(examineResult);
            }
            catch (Exception e)
            {
                dialogFactory.ShowErrorMessage(e);
            }

            var retry = dialogFactory.ShowExamineResultDialog(value);

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
                LaunchTraining();
            }
            else
            {
                Dispose();
                ExitInMainMenu();
            }
        }

        public void Initialize()
        {
            CreateCommands();
            InitializeInnerPages();
        }

        public void LaunchTraining()
        {
            GoTraining(CurrentAlgorithm);
        }

        public void NavigateOnInnerPage(Enum page)
        {
            viewInjectionManager.Navigate(Regions.InnerRegion, page);
            CurrentPageKey = page;
            hintService.OnNavigated(page);
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