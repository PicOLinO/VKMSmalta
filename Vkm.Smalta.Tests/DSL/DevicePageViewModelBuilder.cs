#region Usings

using System.Collections.Generic;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Domain;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.Tests.Fakes.ServicesAndFactories;
using Vkm.ComplexSim.View.ViewModel;

#endregion

namespace Vkm.ComplexSim.Tests.DSL
{
    public class DevicePageViewModelBuilder : BaseBuilder
    {
        private Algorithm algorithm = new Algorithm(new Dictionary<string, int>(), new Dictionary<string, int>());
        private DeviceEntry deviceEntry = new DeviceEntry();
        private ApplicationMode mode = ApplicationMode.Training;

        public DevicePageViewModelBuilder(IAppContext app, DialogFactoryStub dialogFactory, HintServiceStub hintService,
                                          LoadingServiceStub loadingService, HistoryService historyService, ViewInjectionManagerStub viewInjectionManager,
                                          DevicesFactory devicesFactory, ActionsFactory actionsFactory,
                                          PagesFactory pagesFactory) : base(app, dialogFactory, hintService, loadingService, historyService, viewInjectionManager, devicesFactory, actionsFactory, pagesFactory)
        {
            algorithm.Actions = new LinkedList<Action>();
        }

        public DevicePageViewModel Please()
        {
            return new DevicePageViewModel(mode, algorithm, deviceEntry, HintService, HistoryService, DialogFactory, ViewInjectionManager, PagesFactory);
        }

        public DevicePageViewModelBuilder WithAlgorithm(Algorithm algorithm)
        {
            this.algorithm = algorithm;
            return this;
        }

        public DevicePageViewModelBuilder WithDeviceEntry(DeviceEntry deviceEntry)
        {
            this.deviceEntry = deviceEntry;
            return this;
        }

        public DevicePageViewModelBuilder WithMode(ApplicationMode mode)
        {
            this.mode = mode;
            return this;
        }
    }
}