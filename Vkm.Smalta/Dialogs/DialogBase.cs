#region Usings

using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs
{
    public class DialogBase : Window, IDisposable
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
            {
                closeButton.Click += OnCloseButtonClick;
            }
            base.OnApplyTemplate();
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
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

        public void Dispose()
        {
            if (GetTemplateChild("closeButton") is Button closeButton)
            {
                closeButton.Click -= OnCloseButtonClick;
            }
        }
    }
}