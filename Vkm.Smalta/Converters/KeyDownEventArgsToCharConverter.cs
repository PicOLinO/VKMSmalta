using System;
using System.Globalization;
using System.Windows.Input;
using DevExpress.Mvvm.UI;

namespace Vkm.Smalta.Converters
{
    public class KeyDownEventArgsToCharConverter : BaseConverter<KeyDownEventArgsToCharConverter>, IEventArgsConverter
    {
        public object Convert(object sender, object args)
        {
            var arguments = (KeyEventArgs) args;
            return arguments.Key;
        }
    }
}