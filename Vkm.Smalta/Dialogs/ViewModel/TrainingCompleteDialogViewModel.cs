using DevExpress.Mvvm;
using Vkm.Smalta.Services;

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class TrainingCompleteDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand GoExamineCommand { get; private set; }
        public DelegateCommand GoRetryCommand { get; private set; }

        public bool IsGoExamine { get; private set; }
        public bool IsGoRetry { get; private set; }
        public bool IsAuthorized => DependencyContainer.GetApp().IsAuthorized;

        public TrainingCompleteDialogViewModel()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            GoExamineCommand = new DelegateCommand(OnGoExamine);
            GoRetryCommand = new DelegateCommand(OnGoRetry);
        }

        private void OnGoRetry()
        {
            IsGoRetry = true;
            CloseCommand.Execute(null);
        }

        private void OnGoExamine()
        {
            IsGoExamine = true;
            CloseCommand.Execute(null);
        }
    }
}