using System.Windows;
using System.Windows.Controls;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View
{
    /// <summary>
    /// Interaction logic for Hint.xaml
    /// </summary>
    public partial class Hint : UserControl
    {
        public Hint()
        {
            InitializeComponent();
            DataContext = new HintViewModel();
        }
    }
}
