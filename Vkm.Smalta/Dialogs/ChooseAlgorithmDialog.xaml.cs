#region Usings

using System.Collections.Generic;
using System.Windows.Controls;
using Vkm.ComplexSim.Dialogs.ViewModel;
using Vkm.ComplexSim.Domain;

#endregion

namespace Vkm.ComplexSim.Dialogs
{
    /// <summary>
    /// Interaction logic for ChoseAlgorithmDialog.xaml
    /// </summary>
    public partial class ChooseAlgorithmDialog
    {
        public ChooseAlgorithmDialog(IEnumerable<Algorithm> algorithms)
        {
            InitializeComponent();
            DataContext = new ChooseAlgorithmDialogViewModel(algorithms);
            Initialize();
        }

        public Algorithm SelectedAlgorithm => (DataContext as ChooseAlgorithmDialogViewModel)?.SelectedAlgorithm;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Close();
        }
    }
}