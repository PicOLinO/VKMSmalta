using System;
using DevExpress.Mvvm;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class CheckResultsDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand RetryCommand { get; set; }
        public bool IsRetry { get; private set; }

        public int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }

        public CheckResultsDialogViewModel(int value)
        {
            CreateCommands();

            Value = value;
        }

        private void CreateCommands()
        {
            RetryCommand = new DelegateCommand(OnRetry);
        }

        private void OnRetry()
        {
            IsRetry = true;
            
        }
    }
}