using DevExpress.Mvvm;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class CheckResultsDialogViewModel : ViewModelBase
    {
        public int Value
        {
            get { return GetProperty(() => Value); }
            set { SetProperty(() => Value, value); }
        }

        public CheckResultsDialogViewModel(int value)
        {
            Value = value;
        }
    }
}