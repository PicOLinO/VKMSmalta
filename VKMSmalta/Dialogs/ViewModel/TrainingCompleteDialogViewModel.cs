using System;
using DevExpress.Mvvm;
using VKMSmalta.Domain;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class TrainingCompleteDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand GoExamineCommand { get; private set; }

        public bool IsGoExamine { get; private set; }

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