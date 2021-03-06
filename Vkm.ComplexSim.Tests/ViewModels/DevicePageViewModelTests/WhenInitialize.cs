﻿#region Usings

using NUnit.Framework;
using Vkm.ComplexSim.Services.Navigate;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.DevicePageViewModelTests
{
    public class WhenInitialize : DevicePageViewModelTestBase
    {
        [Test]
        public void AllCommandsAreCreated()
        {
            ViewModel.Initialize();

            Assert.That(ViewModel.CheckResultCommand, Is.Not.Null);
            Assert.That(ViewModel.GoForwardCommand, Is.Not.Null);
            Assert.That(ViewModel.GoPreviousCommand, Is.Not.Null);
        }

        [Test]
        public void InnerPagesAreInitialized()
        {
            ViewModel.Pages.Clear();

            ViewModel.Initialize();

            Assert.That(ViewModel.Pages.Count, Is.GreaterThan(0));
        }

        [Test]
        public void NavigationIsRaised()
        {
            ViewModel.Initialize();

            Assert.That(ViewModel.CurrentPageKey, Is.Not.EqualTo(null));
            Assert.That(HintService.PageNavigatedOn, Is.Not.EqualTo(null));
            Assert.That(ViewInjectionManager.CurrentPages[Regions.InnerRegion], Is.Not.EqualTo(null));
        }
    }
}