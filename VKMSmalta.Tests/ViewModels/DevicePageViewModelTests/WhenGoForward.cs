using NUnit.Framework;
using VKMSmalta.Services.Navigate;

namespace VKMSmalta.Tests.ViewModels.DevicePageViewModelTests
{
    public class WhenGoForward : DevicePageViewModelTestBase
    {
        [Test]
        public void CurrentPageKeyIsChanged()
        {
            var previousPageKey = ViewModel.CurrentPageKey;

            ViewModel.GoForwardCommand.Execute(null);

            Assert.That(ViewModel.CurrentPageKey, Is.Not.EqualTo(previousPageKey));
        }

        [Test]
        public void HintServiceNavigatedMethodWasRaised()
        {
            var previousHintServicePage = HintService.PageNavigatedOn;

            ViewModel.GoForwardCommand.Execute(null);

            Assert.That(HintService.PageNavigatedOn, Is.Not.EqualTo(previousHintServicePage));
        }

        [Test]
        public void ThenNavigated()
        {
            ViewModel.GoForwardCommand.Execute(null);

            Assert.That(VIewInjectionManagerStub.CurrentPages[Regions.InnerRegion], Is.Not.EqualTo(InnerRegionPage.Empty));
        }
    }
}