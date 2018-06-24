#region Usings

using DevExpress.Mvvm;

#endregion

namespace VKMSmalta.Dialogs.ViewModel
{
    public class DialogViewModelBase : ViewModelBase
    {
        public DelegateCommand<bool?> CloseCommand { get; set; }
    }
}