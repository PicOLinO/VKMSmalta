#region Usings

using Vkm.ComplexSim.ViewModel;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.MainPageViewModelTests
{
    public class MainPageViewModelTestBase : TestBase
    {
        protected override void Setup()
        {
            base.Setup();

            ViewModel = new MainPageViewModel();
        }

        protected MainPageViewModel ViewModel;
    }
}