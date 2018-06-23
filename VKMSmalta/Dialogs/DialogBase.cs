#region Usings

using System.Windows;
using DevExpress.Mvvm;
using VKMSmalta.Dialogs.ViewModel;

#endregion

namespace VKMSmalta.Dialogs
{
    public class DialogBase : Window
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