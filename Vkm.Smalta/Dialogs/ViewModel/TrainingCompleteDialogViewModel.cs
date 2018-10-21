#region Usings

using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Services;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public class TrainingCompleteDialogViewModel : DialogViewModelBase
    {
        public TrainingCompleteDialogViewModel()
        {
            CreateCommands();
        }

        public ICommand GoExamineCommand { get; private set; }
        public ICommand GoRetryCommand { get; private set; }
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