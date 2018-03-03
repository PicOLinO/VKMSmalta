using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VKMSmalta.Dialogs.ViewModel;
using VKMSmalta.Domain;

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
        }

        public Algorithm SelectedAlgorithm => (DataContext as ChooseAlgorithmDialogViewModel)?.SelectedAlgorithm;

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Close();
        }
    }
}
