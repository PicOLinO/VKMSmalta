#region Usings

using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI;
using VKMSmalta.Dialogs.ViewModel;

#endregion

namespace VKMSmalta.Dialogs
{
    public class DialogBase : WinUIDialogWindow
    {
        protected virtual void CreateCommands()
        {
            var vm = (DialogViewModelBase)DataContext;
            vm.CloseCommand = new DelegateCommand<bool?>(OnClosing);
        }
        
        private void OnClosing(bool? parameter = null)
        {
            DialogResult = parameter;
            Close();
        }
    }
}