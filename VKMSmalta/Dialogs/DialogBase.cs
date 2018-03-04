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
            var baseDialogResources = XAMLEx.PackagesHelper.GetPathFromDefaultPackage("Dialogs/DialogResources.xaml");
            Resources = new ResourceDictionary {Source = new Uri(baseDialogResources) };
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