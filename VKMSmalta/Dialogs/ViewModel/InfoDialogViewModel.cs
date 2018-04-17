namespace VKMSmalta.Dialogs.ViewModel
{
    public class InfoDialogViewModel : DialogViewModelBase
    {
        public InfoDialogViewModel(string infoText)
        {
            InfoText = infoText;
        }

        public string InfoText
        {
            get { return GetProperty(() => InfoText); }
            set { SetProperty(() => InfoText, value); }
        }
    }
}