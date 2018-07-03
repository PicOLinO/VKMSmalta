#region Usings

using VKMSmalta.ViewModel;

#endregion

namespace VKMSmalta.Tests.ViewModels.MainPageViewModelTests
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