#region Usings

using VKMSmalta.Dialogs.ViewModel;

#endregion

namespace VKMSmalta.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class InfoDialog
    {
        public InfoDialog(string infoText)
        {
            InitializeComponent();
            DataContext = new InfoDialogViewModel(infoText);
            CreateCommands();
        }
    }
}