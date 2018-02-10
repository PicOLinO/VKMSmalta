using System.Windows;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View
{
    /// <summary>
    /// Interaction logic for Hint.xaml
    /// </summary>
    public partial class Hint : Window
    {
        public Hint(string hintText)
        {
            InitializeComponent();
            DataContext = new HintViewModel(hintText);
        }
    }
}
