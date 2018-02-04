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

namespace VKMSmalta.Dialogs
{
    /// <summary>
    /// Interaction logic for CheckResultsDialog.xaml
    /// </summary>
    public partial class CheckResultsDialog : Window
    {
        public CheckResultsDialog(int value)
        {
            InitializeComponent();
            DataContext = new CheckResultsDialogViewModel(value);
        }
    }
}
