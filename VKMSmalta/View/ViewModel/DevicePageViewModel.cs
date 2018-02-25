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
                           //Тумблеры снизу
                           new VkmThumblerViewModel(0, "thumbler_imitator") { PosTop = 595, PosLeft = 375 },
                           new VkmThumblerViewModel(0, "thumbler_antenna_leftside") { PosTop = 600, PosLeft = 660 },
                           new VkmThumblerViewModel(0, "thumbler_antenna_rightside") { PosTop = 600, PosLeft = 750 },
                           new VkmThumblerViewModel(0, "thumbler_light") { PosTop = 670, PosLeft = 750 },
                           
                           //Тумблеры справа сверху
                           new VkmThumblerViewModel(0, "thumbler_power") { PosTop = 200, PosLeft = 350 },
                           new VkmThumblerViewModel(0, "thumbler_cold") { PosTop = 200, PosLeft = 350 },
                           new VkmThumblerViewModel(0, "thumbler_autosarpp") { PosTop = 200, PosLeft = 350 },
                           new VkmThumblerViewModel(0, "thumbler_aircontrol") { PosTop = 200, PosLeft = 350 },
                           
                           //Тумблеры справа снизу
                           new VkmThumblerViewModel(0, "thumbler_cooler") { PosTop = 200, PosLeft = 350 },
                           new VkmThumblerViewModel(0, "thumbler_light_maintance") { PosTop = 200, PosLeft = 350 },
                           new VkmThumblerViewModel(0, "thumbler_light_advanced") { PosTop = 200, PosLeft = 350 },
                           new VkmThumblerViewModel(0, "thumbler_light_table") { PosTop = 200, PosLeft = 350 },

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