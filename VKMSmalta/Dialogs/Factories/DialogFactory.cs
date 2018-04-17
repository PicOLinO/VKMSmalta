using VKMSmalta.Services;

namespace VKMSmalta.Dialogs.Factories
{
    public class DialogFactory
    {
        public void ShowLoginDialog()
        {
            var authUri = DependencyContainer.Instance.Config.AdminUri.AdminAuthorizeUri;
            var loginDialog = new LoginDialog(authUri);
            loginDialog.ShowDialog();
        }

        public void ShowRegisterDialog()
        {
            var registerUri = DependencyContainer.Instance.Config.AdminUri.AdminRegisterUri;
            var registerDialog = new RegisterDialog(registerUri, this);
            registerDialog.ShowDialog();
        }

        public void ShowInfoDialog(string infoText)
        {
            var infoDialog = new InfoDialog(infoText);
            infoDialog.ShowDialog();
        }
    }
}