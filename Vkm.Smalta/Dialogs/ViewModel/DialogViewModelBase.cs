#region Usings

using System.Windows.Input;
using DevExpress.Mvvm;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class DialogViewModelBase : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }
    }
}