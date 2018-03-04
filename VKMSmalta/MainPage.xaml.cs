using System.Windows;
using System.Windows.Controls;
using VKMSmalta.ViewModel;

namespace VKMSmalta
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }

        private void PART_MediaBackground_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            var element = (MediaElement) sender;
            element.Stop();
            element.Play();
        }

        private void PART_MediaBackground_OnLoaded(object sender, RoutedEventArgs e)
        {
            var element = (MediaElement)sender;
            element.Play();
        }

        private void PART_MediaBackground_OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            throw e.ErrorException;
        }
    }
}
