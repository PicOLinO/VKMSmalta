#region Usings

using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.Tests.Fakes.ServicesAndFactories;

#endregion

namespace Vkm.ComplexSim.Tests.DSL
{
    public class BaseBuilder
    {
        public BaseBuilder(IAppContext app, DialogFactoryStub dialogFactory, HintServiceStub hintService, LoadingServiceStub loadingService,
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

        protected ActionsFactory ActionsFactory { get; }
        protected IAppContext App { get; }

        protected DevicesFactory DevicesFactory { get; }
        protected DialogFactoryStub DialogFactory { get; }
        protected HintServiceStub HintService { get; }
        protected HistoryService HistoryService { get; }
        protected LoadingServiceStub LoadingService { get; }
        protected PagesFactory PagesFactory { get; }
        protected ViewInjectionManagerStub ViewInjectionManager { get; }
    }
}