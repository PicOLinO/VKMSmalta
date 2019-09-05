#region Usings

using System;
using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Properties;

#endregion

namespace Vkm.ComplexSim.Dialogs.ViewModel
{
    public class InfoDialogViewModel : DialogViewModelBase, IDisposable
    {
        private MemoryStream documentReaderStream;
        private Package package;
        private XpsDocument xpsDocument;

        public InfoDialogViewModel()
        {
            CreateCommands();
            ShowLicenseCommand.Execute(null);
        }

        public FixedDocumentSequence DocumentInDocumentViewer
        {
            get { return GetProperty(() => DocumentInDocumentViewer); }
            set { SetProperty(() => DocumentInDocumentViewer, value); }
        }

        public bool IsShowAboutDeviceInfoButtonEnabled
        {
            get { return GetProperty(() => IsShowAboutDeviceInfoButtonEnabled); }
            set { SetProperty(() => IsShowAboutDeviceInfoButtonEnabled, value); }
        }

        public bool IsShowLicenseButtonEnabled
        {
            get { return GetProperty(() => IsShowLicenseButtonEnabled); }
            set { SetProperty(() => IsShowLicenseButtonEnabled, value); }
        }

        public ICommand ShowAboutDeviceInfoCommand { get; private set; }

        public ICommand ShowLicenseCommand { get; private set; }

        public string TextInTextBox
        {
            get { return GetProperty(() => TextInTextBox); }
            set { SetProperty(() => TextInTextBox, value); }
        }

        private void CreateCommands()
        {
            ShowLicenseCommand = new DelegateCommand(OnShowLicense);
            ShowAboutDeviceInfoCommand = new DelegateCommand(OnShowAboutDeviceInfo);
        }

        private void OnShowAboutDeviceInfo()
        {
            var packageUri = new Uri("memorystream://Documentation.xps");
            if (PackageStore.GetPackage(packageUri) == null)
            {
                documentReaderStream = new MemoryStream(Resources.Documentation);

                package = Package.Open(documentReaderStream);

                PackageStore.AddPackage(packageUri, package);
                xpsDocument = new XpsDocument(package, CompressionOption.Maximum, packageUri.AbsoluteUri);

                DocumentInDocumentViewer = xpsDocument.GetFixedDocumentSequence();
            }

            IsShowAboutDeviceInfoButtonEnabled = false;
            IsShowLicenseButtonEnabled = true;
        }

        private void OnShowLicense()
        {
            TextInTextBox = System.Text.Encoding.UTF8.GetString(Resources.license);
            IsShowLicenseButtonEnabled = false;
            IsShowAboutDeviceInfoButtonEnabled = true;
        }

        #region IDisposable

        public void Dispose()
        {
            if (xpsDocument != null)
            {
                xpsDocument.Close();
                PackageStore.RemovePackage(xpsDocument.Uri);
                package?.Close();
                documentReaderStream?.Close();
            }
        }

        #endregion
    }
}