#region Usings

using Vkm.Smalta.Dialogs.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for CheckResultsDialog.xaml
    /// </summary>
    public partial class CheckResultsDialog
    {
        public CheckResultsDialog(int value)
        {
            InitializeComponent();
            var vm = new CheckResultsDialogViewModel(value);
            DataContext = vm;
            Initialize();
        }
    }
}