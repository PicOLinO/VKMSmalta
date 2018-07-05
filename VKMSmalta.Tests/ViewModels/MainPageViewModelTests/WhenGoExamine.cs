using NUnit.Framework;
using Vkm.Smalta.Services.Navigate;

namespace Vkm.Smalta.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenGoExamine : MainPageViewModelTestBase
    {
        [Test]
        public void ChooseAlgorithmDialogIsShown()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(DialogFactory.IsChooseAlgorithmDialogShown, Is.True);
        }

        [Test]
        public void InnerPajesAreCreated()
        {
            ViewInjectionManagerStub.InjectedOuterPages.Clear();

            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManagerStub.InjectedOuterPages.Count > 0);
        }

        [Test]
        public void NavigatedOnDevicePage()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManagerStub.CurrentPages[Regions.OuterRegion], Is.Not.EqualTo(OuterRegionPages.MainMenu));
        }

        [Test]
        public void ExamineIsGoes()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManagerStub.InjectedOuterPages[OuterRegionPages.Device].Mode, Is.EqualTo(ApplicationMode.Examine));
        }
    }
}