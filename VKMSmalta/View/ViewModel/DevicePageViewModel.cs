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
                           //Тумблеры в середине
                           new VkmThumblerViewModel(0, "thumbler_1channel") { PosTop = 285, PosLeft = 330, StartupRotation = 90 },
                           new VkmThumblerViewModel(0, "thumbler_2channel") { PosTop = 330, PosLeft = 330, StartupRotation = 90 },
                           new VkmThumblerViewModel(0, "thumbler_3channel") { PosTop = 375, PosLeft = 330, StartupRotation = 90 },
                           new VkmThumblerViewModel(0, "thumbler_4channel") { PosTop = 420, PosLeft = 330, StartupRotation = 90 },

                           //Тумблеры снизу
                           new VkmThumblerViewModel(1, "thumbler_imitator") { PosTop = 595, PosLeft = 375 },
                           new VkmThumblerViewModel(0, "thumbler_antenna_leftside") { PosTop = 600, PosLeft = 660 },
                           new VkmThumblerViewModel(0, "thumbler_antenna_rightside") { PosTop = 600, PosLeft = 750 },
                           new VkmThumblerViewModel(0, "thumbler_light") { PosTop = 670, PosLeft = 750 },
                           
                           //Тумблеры справа сверху
                           new VkmThumblerViewModel(0, "thumbler_power") { PosTop = 70, PosLeft = 1189 },
                           new VkmThumblerViewModel(0, "thumbler_cold") { PosTop = 70, PosLeft = 1235 },
                           new VkmThumblerViewModel(0, "thumbler_autosarpp") { PosTop = 70, PosLeft = 1287 },
                           new VkmThumblerViewModel(0, "thumbler_aircontrol") { PosTop = 70, PosLeft = 1340 },
                           
                           //Тумблеры справа снизу
                           new VkmThumblerViewModel(0, "thumbler_cooler") { PosTop = 660, PosLeft = 1180 },
                           new VkmThumblerViewModel(0, "thumbler_light_maintance") { PosTop = 660, PosLeft = 1223 },
                           new VkmThumblerViewModel(0, "thumbler_light_advanced") { PosTop = 660, PosLeft = 1270 },
                           new VkmThumblerViewModel(0, "thumbler_light_table") { PosTop = 660, PosLeft = 1317 }
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