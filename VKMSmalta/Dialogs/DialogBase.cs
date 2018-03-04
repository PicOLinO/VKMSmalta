#region Usings

using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.WindowsUI;

#endregion

namespace VKMSmalta.Dialogs
{
    public class DialogBase : WinUIDialogWindow
    {
        protected DialogBase()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClosing));
            Resources = new ResourceDictionary {Source = new Uri("pack://application:,,,/Dialogs/DialogResources.xaml") };
        }

        private void OnClosing(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}