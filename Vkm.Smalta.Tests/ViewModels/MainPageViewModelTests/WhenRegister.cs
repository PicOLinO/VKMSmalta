#region Usings

using NUnit.Framework;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenRegister : MainPageViewModelTestBase
    {
        [Test]
        public void IfRegisterIsSuccessLoginDialogIsShown()
        {
            ViewModel.RegisterCommand.Execute(null);

            Assert.That(DialogFactory.IsLoginDialogShown, Is.True);
        }

        [Test]
        public void RegisterDialogIsShown()
        {
            ViewModel.RegisterCommand.Execute(null);

            Assert.That(DialogFactory.IsRegisterDialogShown, Is.True);
        }
    }
}