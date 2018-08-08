using System;
using System.Windows;
using DevExpress.Mvvm;

namespace Vkm.Smalta.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBoxDIalog.xaml
    /// </summary>
    public partial class MessageBoxDialog
    {
        public MessageBoxDialog(string messageBoxText, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        {
            InitializeComponent();
            Initialize(messageBoxText, button, icon, defaultResult);
        }

        private void Initialize(string messageBoxText, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        {
            PART_MessageTextBlock.Text = messageBoxText;

            switch (button)
            {
                case MessageButton.OK:
                    PART_Button1.Visibility = Visibility.Collapsed;
                    PART_Button2.Visibility = Visibility.Collapsed;
                    PART_Button3.Content = "Oк";

                    PART_Button3.IsDefault = true;
                    break;
                case MessageButton.OKCancel:
                    PART_Button1.Visibility = Visibility.Collapsed;
                    PART_Button2.Content = "Ок";
                    PART_Button3.Content = "Отмена";

                    PART_Button2.IsDefault = true;
                    PART_Button3.IsCancel = true;
                    break;
                case MessageButton.YesNoCancel:
                    PART_Button1.Content = "Да";
                    PART_Button2.Content = "Нет";
                    PART_Button3.Content = "Отмена";

                    PART_Button2.IsDefault = true;
                    PART_Button3.IsCancel = true;
                    break;
                case MessageButton.YesNo:
                    PART_Button1.Visibility = Visibility.Collapsed;
                    PART_Button2.Content = "Да";
                    PART_Button3.Content = "Нет";

                    PART_Button2.IsDefault = true;
                    PART_Button3.IsCancel = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }

        }
    }
}
