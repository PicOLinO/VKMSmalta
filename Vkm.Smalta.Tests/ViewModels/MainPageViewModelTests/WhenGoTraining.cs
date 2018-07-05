using NUnit.Framework;
using Vkm.Smalta.Services.Navigate;

namespace Vkm.Smalta.Tests.ViewModels.MainPageViewModelTests
{
    public class WhenGoTraining : MainPageViewModelTestBase
    {
        [Test]
        public void ChooseAlgorithmDialogIsShown()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(DialogFactory.IsChooseAlgorithmDialogShown, Is.True);
        }

        [Test]
        public void InnerPajesAreCreated()
        {
            ViewInjectionManagerStub.InjectedOuterPages.Clear();

            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManagerStub.InjectedOuterPages.Count, Is.GreaterThan(0));
        }

        [Test]
        public void NavigatedOnDevicePage()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManagerStub.CurrentPages[Regions.OuterRegion], Is.Not.EqualTo(OuterRegionPages.MainMenu));
        }

        [Test]
        public void TrainingIsStart()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManagerStub.InjectedOuterPages[OuterRegionPages.Device].Mode, Is.EqualTo(ApplicationMode.Training));
        }
    }
}