#region Usings

using NUnit.Framework;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.DevicePageViewModelTests
{
    public class WhenEndTraining : DevicePageViewModelTestBase
    {
        [Test]
        public void IfTrainingCompleteDialogReturnTrueThenGoExamine()
        {
            ViewModel.EndTraining();

            Assert.That(ViewModel.Mode, Is.EqualTo(ApplicationMode.Examine));
        }

        [Test]
        public void TrainingCompleteDialogIsShown()
        {
            ViewModel.EndTraining();

            Assert.That(DialogFactory.TrainingCompleteDialogShown, Is.True);
        }
    }
}