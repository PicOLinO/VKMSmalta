using DevExpress.Mvvm;

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class MessageBoxDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand CloseOkCommand;
        public DelegateCommand CloseYesCommand;
        public DelegateCommand CloseNoCommand;
        public DelegateCommand CloseCancelCommand;

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

        private void OnCloseNo()
        {
            MessageResult = MessageResult.No;
            CloseCommand.Execute(false);
        }

        private void OnCloseCancel()
        {
            MessageResult = MessageResult.Cancel;
            CloseCommand.Execute(false);
        }

        private void OnCloseYes()
        {
            MessageResult = MessageResult.Yes;
            CloseCommand.Execute(true);
        }

        private void OnCloseOk()
        {
            MessageResult = MessageResult.OK;
            CloseCommand.Execute(true);
        }
    }
}