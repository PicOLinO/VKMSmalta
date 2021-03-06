﻿#region Usings

using System.Windows;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs;

#endregion

namespace Vkm.ComplexSim.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        #region IMessageBoxService

        public MessageResult Show(string messageBoxText, string caption, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        {
            using (var dialog = new MessageBoxDialog(messageBoxText, button, icon, defaultResult))
            {
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return dialog.MessageResult;
            }
        }

        #endregion
    }
}