using NUnit.Framework;

namespace Vkm.Smalta.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenRegister : MainPageViewModelTestBase
    {
        [Test]
        public void RegisterDialogIsShown()
        {
            ViewModel.RegisterCommand.Execute(null);

            Assert.That(DialogFactory.IsRegisterDialogShown, Is.True);
        }

        [Test]
        public void IfRegisterIsSuccessLoginDialogIsShown()
        {
            ViewModel.RegisterCommand.Execute(null);

            Assert.That(DialogFactory.IsLoginDialogShown, Is.True);
        }
    }
}