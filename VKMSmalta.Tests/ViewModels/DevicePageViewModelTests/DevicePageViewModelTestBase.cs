using System.Collections.Generic;
using NUnit.Framework;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

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
            ViewModel = new DevicePageViewModel(ApplicationMode.Training, new Algorithm(startStateOfElements, endStateOfElements), HintService, historyService, DialogFactory);
        }

        protected DevicePageViewModel ViewModel { get; private set; }
    }
}