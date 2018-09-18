using NUnit.Framework;
using Vkm.Smalta.Services.Navigate;

namespace Vkm.Smalta.Tests.ViewModels.DevicePageViewModelTests
{
    public class WhenGoPrevious : DevicePageViewModelTestBase
    {
        [Test]
        public void CurrentPageKeyIsChanged()
        {
            var previousPageKey = ViewModel.CurrentPageKey;

            ViewModel.GoPreviousCommand.Execute(null);

            Assert.That(ViewModel.CurrentPageKey, Is.Not.EqualTo(previousPageKey));
        }

        [Test]
        public void HintServiceNavigatedMethodWasRaised()
        {
            var previousHintServicePage = HintService.PageNavigatedOn;

            ViewModel.GoPreviousCommand.Execute(null);

            Assert.That(HintService.PageNavigatedOn, Is.Not.EqualTo(previousHintServicePage));
        }

        [Test]
        public void ThenNavigated()
        {
            ViewModel.GoPreviousCommand.Execute(null);

            Assert.That(ViewInjectionManager.CurrentPages[Regions.InnerRegion], Is.Not.EqualTo(null));
        }
    }
}