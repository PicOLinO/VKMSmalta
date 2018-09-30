#region Usings

using System.Windows.Input;
using DevExpress.Mvvm.UI;

#endregion

namespace Vkm.Smalta.Converters.EventArgsConverters
{
    public class KeyDownEventArgsToCharConverter : BaseConverter<KeyDownEventArgsToCharConverter>, IEventArgsConverter
    {
        #region IEventArgsConverter

        public object Convert(object sender, object args)
        {
            var arguments = (KeyEventArgs) args;
            return arguments.Key;
        }

        #endregion
    }
}