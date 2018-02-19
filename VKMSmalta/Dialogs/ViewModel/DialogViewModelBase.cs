using System;
using DevExpress.Mvvm;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class DialogViewModelBase : ViewModelBase
    {
        public DelegateCommand CloseDialogCommand { get; set; }
    }
}