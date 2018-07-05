#region Usings

using DevExpress.Mvvm;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class DialogViewModelBase : ViewModelBase
    {
        public DelegateCommand<bool?> CloseCommand { get; set; }
    }
}