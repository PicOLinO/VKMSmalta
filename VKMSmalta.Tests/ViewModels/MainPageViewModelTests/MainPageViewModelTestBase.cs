#region Usings

using Vkm.Smalta.ViewModel;

#endregion

namespace Vkm.Smalta.Tests.ViewModels.MainPageViewModelTests
{
    public class MainPageViewModelTestBase : TestBase
    {
        protected override void Setup()
        {
            base.Setup();

            ViewModel = new MainPageViewModel(HintService, DialogFactory, ViewInjectionManagerStub);
        }

        protected MainPageViewModel ViewModel;
    }
}