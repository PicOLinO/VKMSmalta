#region Usings

using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs
{
    public class DialogBase : Window
    {
        protected DialogBase()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ShowInTaskbar = false;
        }

        protected void Initialize()
        {
            CreateCommands();
        }

        public override void OnApplyTemplate()
        {
            if (GetTemplateChild("closeButton") is Button closeButton)
                closeButton.Click += (sender, args) => Close();
            base.OnApplyTemplate();
        }

        private void CreateCommands()
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