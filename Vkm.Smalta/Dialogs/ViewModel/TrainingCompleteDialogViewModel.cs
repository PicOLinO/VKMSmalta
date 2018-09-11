using DevExpress.Mvvm;
using Vkm.Smalta.Services;

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class TrainingCompleteDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand GoExamineCommand { get; private set; }

        public bool IsGoExamine { get; private set; }
        public bool IsAuthorized => DependencyContainer.GetApp().IsAuthorized;

        public TrainingCompleteDialogViewModel()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            GoExamineCommand = new DelegateCommand(OnGoExamine);
        }

        private void OnGoExamine()
        {
            IsGoExamine = true;
            CloseCommand.Execute(null);
        }
    }
}