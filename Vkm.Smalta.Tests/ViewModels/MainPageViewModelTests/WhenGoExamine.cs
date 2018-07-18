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
            ViewInjectionManager.InjectedOuterPages.Clear();

            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages.Count > 0);
        }

        [Test]
        public void NavigatedOnDevicePage()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManager.CurrentPages[Regions.OuterRegion], Is.Not.EqualTo(OuterRegionPages.MainMenu));
        }

        [Test]
        public void ExamineIsGoes()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages[OuterRegionPages.Device].Mode, Is.EqualTo(ApplicationMode.Examine));
        }
    }
}