#region Usings

using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

#endregion

namespace VKMSmalta.Tests.ViewModels.DevicePageViewModelTests
{
    public class DevicePageViewModelTestBase : TestBase
    {
        protected override void Setup()
        {
            base.Setup();

            var historyService = new HistoryService();

            var startStateOfElements = new Dictionary<string, int>();
            var endStateOfElements = new Dictionary<string, int>();
            var algorithm = new Algorithm(startStateOfElements, endStateOfElements);

            ViewModel = new DevicePageViewModel(ApplicationMode.Training, algorithm, HintService, historyService, DialogFactory, ViewInjectionManagerStub);
        }

        protected DevicePageViewModel ViewModel { get; private set; }
    }
}