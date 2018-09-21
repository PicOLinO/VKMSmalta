#region Usings

using System.Collections.Generic;
using Vkm.Smalta.Dialogs.Factories.Algorithms;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.Tests.ViewModels.DevicePageViewModelTests
{
    public class DevicePageViewModelTestBase : TestBase
    {
        protected DeviceEntry SmaltaDevice => DevicesFactory.GetSmaltaDevice(new SmaltaAlgorithmsFactory(ActionsFactory));
        protected DeviceEntry RlsOncDevice => DevicesFactory.GetImpulseRadioLocationStation(new RlsOncAlgorithmsFactory(ActionsFactory));

        protected DevicePageViewModel ViewModel { get; set; }

        protected Algorithm EmptyAlgorithm { get; private set; }

        protected override void Setup()
        {
            base.Setup();

            EmptyAlgorithm = new Algorithm(new Dictionary<string, int>(), new Dictionary<string, int>());
            EmptyAlgorithm.Actions = new LinkedList<Action>();
            ViewModel = GiveMe.DevicePage().WithMode(ApplicationMode.Training).WithDeviceEntry(SmaltaDevice).WithAlgorithm(EmptyAlgorithm).Please();

        }
    }
}