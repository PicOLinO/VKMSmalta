﻿#region Usings

using NUnit.Framework;
using Vkm.ComplexSim.Services.Navigate;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.DevicePageViewModelTests
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

            Assert.That(ViewInjectionManager.CurrentPages[Regions.InnerRegion], Is.Not.EqualTo(null));
        }
    }
}