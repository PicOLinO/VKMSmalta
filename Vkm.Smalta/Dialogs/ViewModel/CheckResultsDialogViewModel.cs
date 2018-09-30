#region Usings

using System.Windows.Input;
using DevExpress.Mvvm;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class CheckResultsDialogViewModel : DialogViewModelBase
    {
        public CheckResultsDialogViewModel(int value)
        {
            CreateCommands();

            Value = value;
        }

        public bool IsRetry { get; private set; }
        public ICommand RetryCommand { get; set; }

        public int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }

        private void CreateCommands()
        {
            RetryCommand = new DelegateCommand(OnRetry);
        }

        private void OnRetry()
        {
            IsRetry = true;
            CloseCommand.Execute(null);
        }
    }
}