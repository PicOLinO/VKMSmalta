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
        public TrainingCompleteDialog(TrainingCompleteDialogViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            Initialize();
        }

        public bool GoExamine => (DataContext as TrainingCompleteDialogViewModel).IsGoExamine;
    }
}