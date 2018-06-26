using VKMSmalta.Dialogs.Factories;

namespace VKMSmalta.Tests.Fakes.ServicesAndFactories
{
    public class DialogFactoryStub : IDialogFactory
    {
        public bool IsInfoDialogShown { get; private set; }
        public bool IsLoginDialogShown { get; private set; }
        public bool IsRegisterDialogShown { get; private set; }

        public void ShowInfoDialog()
        {
            IsInfoDialogShown = true;
        }

        public bool ShowLoginDialog()
        {
            IsLoginDialogShown = true;
            return true;
        }

        public bool ShowRegisterDialog()
        {
            IsRegisterDialogShown = true;
            return true;
        }
    }
}