using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm.UI;

namespace Vkm.ComplexSim.Converters.EventArgsConverters
{
    /// <summary>
    /// Может понадобиться, а может и нет =) Удалить после добавления нового симулятора, если он также не будет использоваться
    /// </summary>
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