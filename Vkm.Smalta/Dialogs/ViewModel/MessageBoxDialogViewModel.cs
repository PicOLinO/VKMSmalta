#region Usings

using DevExpress.Mvvm;

#endregion

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class MessageBoxDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand CloseCancelCommand;
        public DelegateCommand CloseNoCommand;
        public DelegateCommand CloseOkCommand;
        public DelegateCommand CloseYesCommand;

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