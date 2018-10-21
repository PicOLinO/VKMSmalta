#region Usings

using Vkm.ComplexSim.Dialogs.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs
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