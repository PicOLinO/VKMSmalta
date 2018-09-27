#region Usings

using DevExpress.Mvvm;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class TrainingCompleteDialogViewModel : DialogViewModelBase
    {
        public TrainingCompleteDialogViewModel()
        {
            CreateCommands();
        }

        public DelegateCommand GoExamineCommand { get; private set; }
        public DelegateCommand GoRetryCommand { get; private set; }
        public bool IsAuthorized => DependencyContainer.GetApp().IsAuthorized;

        public bool IsGoExamine { get; private set; }
        public bool IsGoRetry { get; private set; }

        private void CreateCommands()
        {
            GoExamineCommand = new DelegateCommand(OnGoExamine);
            GoRetryCommand = new DelegateCommand(OnGoRetry);
        }

        private void OnGoExamine()
        {
            IsGoExamine = true;
            CloseCommand.Execute(null);
        }

        private void OnGoRetry()
        {
            IsGoRetry = true;
            CloseCommand.Execute(null);
        }
    }
}