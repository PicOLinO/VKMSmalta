#region Usings

using System.Windows.Controls;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Domain;

#endregion

namespace VKMSmalta.Dialogs
{
    /// <summary>
    /// Interaction logic for ChoseAlgorithmDialog.xaml
    /// </summary>
    public partial class ChooseAlgorithmDialog
    {
        public ChooseAlgorithmDialog(ChooseAlgorithmDialogViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            Initialize();
        }

        public Algorithm SelectedAlgorithm => (DataContext as ChooseAlgorithmDialogViewModel)?.SelectedAlgorithm;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Close();
        }
    }
}