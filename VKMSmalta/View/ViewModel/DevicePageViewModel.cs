using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm;
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
        public ObservableCollection<ElementViewModelBase> Elements { get; set; }
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
            Elements = new ObservableCollection<ElementViewModelBase>
                       {
                           new VkmThumblerViewModel { Name = "vkt101", PosTop = 200, PosLeft = 350 },
                           new VkmRotateWheelViewModel(1, -20, 20, 5) { Name = "vkwhl", PosTop = 500, PosLeft = 400 }
                       };
        }

        private void GoTraining(Algorithm algorithm)
        {
            HintService.Instance.StartTraining(algorithm, Elements.ToList());
        }

        private void OnCheckResult()
        {
            var value = HistoryService.Instance.GetValueByAlgorithm(CurrentAlgorithm, Elements.Cast<IValuableElement>().ToList());
            VkmNavigationService.Instance.ExitDevicePageWithResult(value);
            Dispose();
        }

        public void Dispose()
        {
            HintService.Instance.Reset();
            HistoryService.Instance.Reset();
        }
    }
}