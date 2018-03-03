#region Usings

using System.Windows.Input;
using DevExpress.Xpf.WindowsUI;

#endregion

namespace VKMSmalta.Dialogs
{
    public class ModernDialog : WinUIDialogWindow
    {
        protected ModernDialog()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, OnClosing));
        }

        protected void OnClosing(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}