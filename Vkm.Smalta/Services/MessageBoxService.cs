﻿using System;
using System.Windows;
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
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
                return dialog.MessageResult;
            }
        }
    }
}