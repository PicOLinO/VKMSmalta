#region Usings

using System.Windows.Input;
using DevExpress.Mvvm;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public class MessageBoxDialogViewModel : DialogViewModelBase
    {
        public ICommand CloseCancelCommand;
        public ICommand CloseNoCommand;
        public ICommand CloseOkCommand;
        public ICommand CloseYesCommand;

        public MessageBoxDialogViewModel()
        {
            CreateCommands();
        }

        public MessageResult MessageResult { get; private set; }

        private void CreateCommands()
        {
            CloseOkCommand = new DelegateCommand(OnCloseOk);
            CloseYesCommand = new DelegateCommand(OnCloseYes);
            CloseNoCommand = new DelegateCommand(OnCloseNo);
            CloseCancelCommand = new DelegateCommand(OnCloseCancel);
        }

        private void OnCloseCancel()
        {
            MessageResult = MessageResult.Cancel;
            CloseCommand.Execute(false);
        }

        private void OnCloseNo()
        {
            MessageResult = MessageResult.No;
            CloseCommand.Execute(false);
        }

        private void OnCloseOk()
        {
            MessageResult = MessageResult.OK;
            CloseCommand.Execute(true);
        }

        private void OnCloseYes()
        {
            MessageResult = MessageResult.Yes;
            CloseCommand.Execute(true);
        }
    }
}