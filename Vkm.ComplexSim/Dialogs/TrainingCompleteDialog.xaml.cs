#region Usings

using Vkm.ComplexSim.Dialogs.ViewModel;

#endregion

namespace Vkm.ComplexSim.Dialogs
{
    /// <summary>
    /// Interaction logic for TrainingCompleteDialog.xaml
    /// </summary>
    public partial class TrainingCompleteDialog
    {
        public TrainingCompleteDialog()
        {
            InitializeComponent();
            DataContext = new TrainingCompleteDialogViewModel();
            Initialize();
        }

        public bool GoExamine => (DataContext as TrainingCompleteDialogViewModel).IsGoExamine;
        public bool GoRetry => (DataContext as TrainingCompleteDialogViewModel).IsGoRetry;
    }
}