using System;
using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs;

namespace Vkm.Smalta.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageResult Show(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        {
            using (var dialog = new MessageBoxDialog(messageBoxText, button, icon, defaultResult))
            {
                var result = dialog.ShowDialog();
                switch (button)
                {
                    case MessageButton.OK:
                        return result.HasValue
                                   ? MessageResult.OK
                                   : MessageResult.None;
                    case MessageButton.OKCancel:
                        if (!result.HasValue)
                        {
                            return MessageResult.None;
                        }
                        if (result.Value)
                        {
                            return MessageResult.OK;
                        }
                        return MessageResult.Cancel;
                    case MessageButton.YesNoCancel:
                        if (!result.HasValue)
                        {
                            return MessageResult.Cancel;
                        }
                        if (result.Value)
                        {
                            return MessageResult.Yes;
                        }
                        return MessageResult.No;
                    case MessageButton.YesNo:
                        if (!result.HasValue)
                        {
                            return MessageResult.None;
                        }
                        if (result.Value)
                        {
                            return MessageResult.Yes;
                        }
                        return MessageResult.No;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(button), button, null);
                }
            }
        }
    }
}