#region Usings

using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Domain;

#endregion

namespace VKMSmalta.Dialogs
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