#region Usings

using System.Windows.Controls;
using Vkm.Smalta.Dialogs.ViewModel;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for ChoseAlgorithmDialog.xaml
    /// </summary>
    public partial class ChooseAlgorithmDialog
    {
        public ChooseAlgorithmDialog(IHintService hintService)
        {
            InitializeComponent();
            DataContext = new ChooseAlgorithmDialogViewModel(hintService);
            Initialize();
        }

        public Algorithm SelectedAlgorithm => (DataContext as ChooseAlgorithmDialogViewModel)?.SelectedAlgorithm;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Close();
        }
    }
}