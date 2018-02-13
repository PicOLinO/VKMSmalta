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

        public ObservableCollection<ElementViewModelBase> Elements { get; set; }

        public DevicePageViewModel(ApplicationMode appMode, Algorithm algorithm)
        {
            InitializeServices();
            CreateCommands();
            InitializeElements();

            if (appMode == ApplicationMode.Training)
            {
                GoTraining(algorithm);
            }
        }

        private void GoTraining(Algorithm algorithm)
        {
            HintService.Instance.StartTraining(algorithm, Elements.ToList());
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
                           new VkmRotateWheelViewModel(20, 5) { Name = "vkwhl", PosTop = 500, PosLeft = 400 }
                       };
        }

        private void OnCheckResult()
        {
            //TODO:Добавление проверки на оценку
            VkmNavigationService.Instance.ExitDevicePageWithResult(5);
            Dispose();
        }

        public void Dispose()
        {
            HintService.Instance.Reset();
            HistoryService.Instance.Reset();
        }
    }
}