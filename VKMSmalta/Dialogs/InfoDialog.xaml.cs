#region Usings

using System.Diagnostics;
using System.Windows.Navigation;
using Vkm.Smalta.Dialogs.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class InfoDialog
    {
        public InfoDialog()
        {
            InitializeComponent();
            DataContext = new InfoDialogViewModel();
            Initialize();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }
    }
}