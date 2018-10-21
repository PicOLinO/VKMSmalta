using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.ViewModel;

namespace Vkm.ComplexSim.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBoxDIalog.xaml
    /// </summary>
    public partial class MessageBoxDialog
    {
        private MessageBoxDialogViewModel ViewModel => (MessageBoxDialogViewModel) DataContext;

        public MessageBoxDialog(string messageBoxText, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        {
            InitializeComponent();
            DataContext = new MessageBoxDialogViewModel();
            Initialize();
            Initialize(messageBoxText, button, icon, defaultResult);
        }

        private void Initialize(string messageBoxText, MessageButton button, MessageIcon icon, MessageResult defaultResult)
        {
            PART_MessageTextBlock.Text = messageBoxText;

            switch (icon)
            {
                case MessageIcon.None:
                    break;
                case MessageIcon.Error:
                    PART_Icon.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Error.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case MessageIcon.Question:
                    PART_Icon.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Question.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case MessageIcon.Warning:
                    PART_Icon.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Warning.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case MessageIcon.Information:
                    PART_Icon.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Information.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(icon), icon, null);
            }

            switch (button)
            {
                case MessageButton.OK:
                    PART_Button1.Visibility = Visibility.Collapsed;
                    PART_Button2.Visibility = Visibility.Collapsed;
                    PART_Button3.Content = "Oк";

                    PART_Button3.IsDefault = true;

                    PART_Button3.Command = ViewModel.CloseOkCommand;
                    break;
                case MessageButton.OKCancel:
                    PART_Button1.Visibility = Visibility.Collapsed;
                    PART_Button2.Content = "Ок";
                    PART_Button3.Content = "Отмена";

                    PART_Button2.IsDefault = true;
                    PART_Button3.IsCancel = true;

                    PART_Button2.Command = ViewModel.CloseOkCommand;
                    PART_Button3.Command = ViewModel.CloseCancelCommand;
                    break;
                case MessageButton.YesNoCancel:
                    PART_Button1.Content = "Да";
                    PART_Button2.Content = "Нет";
                    PART_Button3.Content = "Отмена";

                    PART_Button2.IsDefault = true;
                    PART_Button3.IsCancel = true;

                    PART_Button1.Command = ViewModel.CloseYesCommand;
                    PART_Button2.Command = ViewModel.CloseNoCommand;
                    PART_Button3.Command = ViewModel.CloseCancelCommand;
                    break;
                case MessageButton.YesNo:
                    PART_Button1.Visibility = Visibility.Collapsed;
                    PART_Button2.Content = "Да";
                    PART_Button3.Content = "Нет";

                    PART_Button2.IsDefault = true;
                    PART_Button3.IsCancel = true;

                    PART_Button2.Command = ViewModel.CloseYesCommand;
                    PART_Button3.Command = ViewModel.CloseNoCommand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }

        }

        public MessageResult MessageResult => ViewModel.MessageResult;
    }
}
