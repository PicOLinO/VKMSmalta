﻿#region Usings

using NUnit.Framework;
using Vkm.ComplexSim.Services.Navigate;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.MainPageViewModelTests
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
        public void ChooseDeviceDialogIsShown()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(DialogFactory.IsChooseDeviceDialogShown, Is.True);
        }

        [Test]
        public void ExamineIsGoes()
        {
            ViewModel.GoExamineCommand.Execute(null);

            Assert.That(ViewInjectionManager.InjectedOuterPages[OuterRegionPages.Device].Mode, Is.EqualTo(ApplicationMode.Examine));
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
    }
}