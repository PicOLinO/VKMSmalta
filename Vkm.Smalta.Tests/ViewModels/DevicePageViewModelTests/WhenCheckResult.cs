#region Usings

using NUnit.Framework;
using Vkm.Smalta.Services.Navigate;

#endregion

namespace Vkm.Smalta.Tests.ViewModels.DevicePageViewModelTests
{
    public class WhenCheckResult : DevicePageViewModelTestBase
    {
        [Test]
        public void IfApplicationModeIsExamineThenExamineResultsIsSended()
        {
            DialogFactory.BoolDialogResult = true;
            ViewModel = GiveMe.DevicePage()
                              .WithMode(ApplicationMode.Examine)
                              .Please();

            ViewModel.CheckResultCommand.Execute(null);

            Assert.That(NetworkService.ExamineResultSendedToAdmin, Is.True);
        }

        [Test]
        public void IfAppModeIsExamineAndShowQuestionDialogAboutExitIsShownAndUserPressedNoThenStopQuiting()
        {
            ViewModel = GiveMe.DevicePage()
                              .WithMode(ApplicationMode.Examine)
                              .Please();

            ViewModel.CheckResultCommand.Execute(null);

            Assert.That(ViewInjectionManager.CurrentPages[Regions.OuterRegion], Is.Not.EqualTo(OuterRegionPages.MainMenu));
        }

        [Test]
        public void IfAppModeIsExamineThenShowQuestionDialogAboutExit()
        {
            ViewModel = GiveMe.DevicePage()
                              .WithMode(ApplicationMode.Examine)
                              .Please();

            ViewModel.CheckResultCommand.Execute(null);

            Assert.That(DialogFactory.IsAskYesNoDialogShown, Is.True);
        }

        [Test]
        public void IfAppModeIsExamineThenShowResultsDialogAppears()
        {
            DialogFactory.BoolDialogResult = true;
            ViewModel = GiveMe.DevicePage()
                              .WithMode(ApplicationMode.Examine)
                              .Please();

            ViewModel.CheckResultCommand.Execute(null);

            Assert.That(DialogFactory.IsExamineResultDialogShown, Is.True);
        }
        //TODO: Не до конца протестировано. Добавить тестов.

        [Test]
        public void IfAppModeIsTrainingThenExitInMainMenu()
        {
            ViewModel = GiveMe.DevicePage()
                              .WithMode(ApplicationMode.Training)
                              .Please();

            ViewModel.CheckResultCommand.Execute(null);

            Assert.That(ViewInjectionManager.CurrentPages[Regions.OuterRegion], Is.EqualTo(OuterRegionPages.MainMenu));
        }
    }
}