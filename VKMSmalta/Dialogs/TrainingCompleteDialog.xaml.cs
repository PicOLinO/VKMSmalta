#region Usings

using VKMSmalta.Dialogs.ViewModel;

#endregion

namespace VKMSmalta.Dialogs
{
    /// <summary>
    /// Interaction logic for TrainingCompleteDialog.xaml
    /// </summary>
    public partial class TrainingCompleteDialog
    {
        public TrainingCompleteDialog()
        {
            InitializeComponent();
            DataContext = new DialogViewModelBase();
            Initialize();
        }
    }
}