using DevExpress.Mvvm;
using VKMSmalta.Dialogs;
using VKMSmalta.Services;

namespace VKMSmalta.View.ViewModel
{
    public class DevicePageViewModel : ViewModelBase
    {
        public DelegateCommand CheckResultCommand { get; set; }

        public DevicePageViewModel(ApplicationMode appMode)
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            CheckResultCommand = new DelegateCommand(OnCheckResult);
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