using System;
using DevExpress.Mvvm;

namespace VKMSmalta.Dialogs.ViewModel
{
    public class DialogViewModelBase : ViewModelBase
    {
        public DelegateCommand CloseCommand { get; set; }
    }
}