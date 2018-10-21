#region Usings

using System;
using System.Diagnostics;
using System.Windows.Navigation;
using Vkm.ComplexSim.Dialogs.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs
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
            PART_DocumentViewer.FitToWidth();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }

        protected override void OnClosing(bool? parameter = null)
        {
            ((IDisposable)DataContext).Dispose();
            base.OnClosing(parameter);
        }
    }
}