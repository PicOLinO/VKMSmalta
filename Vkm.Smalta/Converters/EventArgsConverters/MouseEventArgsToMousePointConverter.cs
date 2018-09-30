using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm.UI;

namespace Vkm.Smalta.Converters.EventArgsConverters
{
    public class MouseEventArgsToMousePointConverter : BaseConverter<MouseEventArgsToMousePointConverter>, IEventArgsConverter
    {
        public object Convert(object sender, object args)
        {
            var arguments = (MouseEventArgs)args;
            var element = (FrameworkElement)sender;
            var point = arguments.GetPosition(element);
            return point;
        }
    }
}