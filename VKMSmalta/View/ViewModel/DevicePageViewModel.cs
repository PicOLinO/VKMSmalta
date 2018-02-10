using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Services;
using VKMSmalta.View.Elements.ViewModel;

namespace VKMSmalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase
    {
        public DelegateCommand CheckResultCommand { get; set; }

        public ObservableCollection<ElementViewModelBase> Elements { get; set; }

        public DevicePageViewModel(ApplicationMode appMode)
        {
            InitializeServices();
            CreateCommands();
            InitializeElements();
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
                           new VkmThumblerViewModel { PosTop = 100, PosLeft = 250 },
                           new VkmRotateWheelViewModel(20, 5) { PosTop = 100, PosLeft = 100 }
                       };
        }

        private void OnCheckResult()
        {
            //TODO:Добавление проверки на оценку
            var dialog = new CheckResultsDialog(5);
            dialog.ShowDialog();
            VkmNavigationService.Instance.GoBack();
        }
    }
}