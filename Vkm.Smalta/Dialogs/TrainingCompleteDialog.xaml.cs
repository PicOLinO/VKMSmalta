#region Usings

using Vkm.Smalta.Dialogs.ViewModel;

#endregion

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for TrainingCompleteDialog.xaml
    /// </summary>
    public partial class TrainingCompleteDialog
    {
        public TrainingCompleteDialog()
        {
            InitializeComponent();
            DataContext = new TrainingCompleteDialog();
            Initialize();
        }

        public bool GoExamine => (DataContext as TrainingCompleteDialogViewModel).IsGoExamine;
    }
}