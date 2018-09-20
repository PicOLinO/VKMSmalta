using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Services;
using Vkm.Smalta.Tests.Fakes.ServicesAndFactories;

namespace Vkm.Smalta.Tests.DSL
{
    public class GiveMe
    {
        protected IAppContext App { get; }
        protected DialogFactoryStub DialogFactory { get; }
        protected HintServiceStub HintService { get; }
        protected LoadingServiceStub LoadingService { get; }
        protected HistoryService HistoryService { get; }
        protected ViewInjectionManagerStub ViewInjectionManager { get; }

        protected DevicesFactory DevicesFactory { get; }
        protected ActionsFactory ActionsFactory { get; }
        protected PagesFactory PagesFactory { get; }

        public GiveMe(IAppContext app, DialogFactoryStub dialogFactory, HintServiceStub hintService, LoadingServiceStub loadingService,
                           HistoryService historyService, ViewInjectionManagerStub viewInjectionManager, DevicesFactory devicesFactory, ActionsFactory actionsFactory,
                           PagesFactory pagesFactory)
        {
            App = app;
            DialogFactory = dialogFactory;
            HintService = hintService;
            LoadingService = loadingService;
            HistoryService = historyService;
            ViewInjectionManager = viewInjectionManager;
            DevicesFactory = devicesFactory;
            ActionsFactory = actionsFactory;
            PagesFactory = pagesFactory;
        }

        public DevicePageViewModelBuilder DevicePage()
        {
            return new DevicePageViewModelBuilder(App, DialogFactory, HintService, LoadingService, HistoryService, ViewInjectionManager, DevicesFactory, ActionsFactory, PagesFactory);
        }
    }
}