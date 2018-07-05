using NUnit.Framework;

namespace Vkm.Smalta.Tests.ViewModels.DevicePageViewModelTests
{
    public class WhenEndTraining : DevicePageViewModelTestBase
    {
        [Test]
        public void TrainingCompleteDialogIsShown()
        {
            ViewModel.EndTraining();

            Assert.That(DialogFactory.TrainingCompleteDialogShown, Is.True);
        }

        [Test]
        public void IfTrainingCompleteDialogReturnTrueThenGoExamine()
        {
            ViewModel.EndTraining();

            Assert.That(ViewModel.Mode, Is.EqualTo(ApplicationMode.Examine));
        }
    }
}