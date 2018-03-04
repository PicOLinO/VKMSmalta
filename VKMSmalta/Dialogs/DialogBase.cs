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
        protected DialogBase()
        {
            Resources = new ResourceDictionary {Source = new Uri("pack://application:,,,/Dialogs/DialogResources.xaml") };
        }

        protected virtual void CreateCommands()
        {
            var vm = (DialogViewModelBase)DataContext;
            vm.CloseCommand = new DelegateCommand(OnClosing);
        }
        
        private void OnClosing()
        {
            Close();
        }
    }
}