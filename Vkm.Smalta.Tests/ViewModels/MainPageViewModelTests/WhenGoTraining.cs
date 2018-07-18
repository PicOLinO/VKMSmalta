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
            ViewInjectionManager.InjectedOuterPages.Clear();

            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages.Count, Is.GreaterThan(0));
        }

        [Test]
        public void NavigatedOnDevicePage()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManager.CurrentPages[Regions.OuterRegion], Is.Not.EqualTo(OuterRegionPages.MainMenu));
        }

        [Test]
        public void TrainingIsStart()
        {
            ViewModel.GoTrainingCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages[OuterRegionPages.Device].Mode, Is.EqualTo(ApplicationMode.Training));
        }
    }
}