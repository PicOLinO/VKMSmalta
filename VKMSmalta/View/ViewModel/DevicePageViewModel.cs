using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using VKMSmalta.Dialogs;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase, IDisposable
    {
        public DelegateCommand CheckResultCommand { get; set; }

        private Algorithm CurrentAlgorithm { get; }

        public ObservableCollection<ElementViewModelBase> Elements
        {
            get { return GetProperty(() => Elements); }
            set { SetProperty(() => Elements, value); }
        }
        public bool IsCheckResultButtonVisible
        {
            get { return GetProperty(() => IsCheckResultButtonVisible); }
            set { SetProperty(() => IsCheckResultButtonVisible, value); }
        }

        public DevicePageViewModel(ApplicationMode appMode, Algorithm algorithm)
        {
            CurrentAlgorithm = algorithm;

            InitializeServices();
            CreateCommands();
            InitializeElements();

            if (appMode == ApplicationMode.Training)
            {
                IsCheckResultButtonVisible = false;
                GoTraining(CurrentAlgorithm);
            }

            if (appMode == ApplicationMode.Examine)
            {
                IsCheckResultButtonVisible = true;
            }
        }

        private void CreateCommands()
        {
            CheckResultCommand = new DelegateCommand(OnCheckResult);
        }

        private void InitializeServices()
        {
            HintService.InitializeService();
            HistoryService.InitializeService();
        }

        private void InitializeElements()
        {
            //TODO: Добавить начальное состояние элементам из CurrentAlgorithm.StartStateOfElements
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           new VkmThumblerViewModel(0, "vkt101") { PosTop = 200, PosLeft = 350 },
                           new VkmRotateWheelViewModel(1, "vkwhl", -20, 25, 5) { PosTop = 500, PosLeft = 400 }
                       };
        }

        private void GoTraining(Algorithm algorithm)
        {
            foreach (var element in Elements)
            {
                element.IsEnabled = false;
            }

            HintService.Instance.StartTraining(algorithm, Elements.ToList());
        }

        private void OnCheckResult()
        {
            var value = HistoryService.Instance.GetValueByAlgorithm(CurrentAlgorithm, Elements.Cast<IValuableNamedElement>().ToList());
            var retry = VkmNavigationService.Instance.ExitDevicePageWithResult(value);

            if (retry)
            {
                InitializeElements();
            }

            Dispose();
        }

        public void Dispose()
        {
            HintService.Instance.Reset();
            HistoryService.Instance.Reset();
        }
    }
}