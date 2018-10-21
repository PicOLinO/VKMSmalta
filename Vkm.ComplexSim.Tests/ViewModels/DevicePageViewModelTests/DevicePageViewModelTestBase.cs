#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Dialogs.Factories.Algorithms;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.View.ViewModel;

#endregion

namespace Vkm.ComplexSim.Tests.ViewModels.DevicePageViewModelTests
{
    public class DevicePageViewModelTestBase : TestBase
    {
        protected override void Setup()
        {
            base.Setup();

            EmptyAlgorithm = new Algorithm(new Dictionary<string, int>(), new Dictionary<string, int>());
            EmptyAlgorithm.Actions = new LinkedList<Action>();
            ViewModel = GiveMe.DevicePage().WithMode(ApplicationMode.Training).WithDeviceEntry(SmaltaDevice).WithAlgorithm(EmptyAlgorithm).Please();
        }

        protected DeviceEntry SmaltaDevice => DevicesFactory.GetSmaltaDevice(new SmaltaAlgorithmsFactory(ActionsFactory));
        protected DeviceEntry RlsOncDevice => DevicesFactory.GetImpulseRadioLocationStation(new RlsOncAlgorithmsFactory(ActionsFactory));

        protected DevicePageViewModel ViewModel { get; set; }

        protected Algorithm EmptyAlgorithm { get; private set; }
    }
}