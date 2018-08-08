using DevExpress.Mvvm;
using Vkm.Smalta.Properties;

namespace Vkm.Smalta.Dialogs.ViewModel
{
    public class InfoDialogViewModel : DialogViewModelBase
    {
        public DelegateCommand ShowLicenseCommand { get; private set; }

        public string TextInTextBox
        {
            get { return GetProperty(() => TextInTextBox); }
            set { SetProperty(() => TextInTextBox, value); }
        }

        public bool IsShowLicenseButtonEnabled
        {
            get { return GetProperty(() => IsShowLicenseButtonEnabled); }
            set { SetProperty(() => IsShowLicenseButtonEnabled, value); }
        }

        public InfoDialogViewModel()
        {
            CreateCommands();
            ShowLicenseCommand.Execute(null);
        }

        private void CreateCommands()
        {
            ShowLicenseCommand = new DelegateCommand(OnShowLicense);
        }

        private void OnShowLicense()
        {
            TextInTextBox = Resources.LICENSE;
            IsShowLicenseButtonEnabled = false;
        }
    }
}