#region Usings

using DevExpress.Mvvm;
using NUnit.Framework;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.Tests.DSL;
using Vkm.ComplexSim.Tests.Fakes.ServicesAndFactories;
using Vkm.ComplexSim.View.Images;

#endregion

namespace Vkm.ComplexSim.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        [SetUp]
        protected virtual void Setup()
        {
            ViewInjectionManager = new ViewInjectionManagerStub();

            App = new AppContext();
            HintService = new HintServiceStub();
            LoadingService = new LoadingServiceStub();
            HistoryService = new HistoryService();
            NetworkService = new NetworkServiceStub();

            ImageRepository = new ImagesRepository(); //TODO: Make stub

            DialogFactory = new DialogFactoryStub();
            ActionsFactory = new ActionsFactory();
            DevicesFactory = new DevicesFactory();
            PagesFactory = new PagesFactory(ImageRepository);

            ServiceContainer.Default.RegisterService(ViewInjectionManager);
            ServiceContainer.Default.RegisterService(HintService);
            ServiceContainer.Default.RegisterService(LoadingService);
            ServiceContainer.Default.RegisterService(HistoryService);
            ServiceContainer.Default.RegisterService(NetworkService);
            
            ServiceContainer.Default.RegisterService(ImageRepository);
            
            ServiceContainer.Default.RegisterService(DialogFactory);
            ServiceContainer.Default.RegisterService(PagesFactory);
            ServiceContainer.Default.RegisterService(DevicesFactory);
            ServiceContainer.Default.RegisterService(ActionsFactory);
            ServiceContainer.Default.RegisterService(App);

            GiveMe = new GiveMe(App, DialogFactory, HintService, LoadingService, HistoryService, ViewInjectionManager, DevicesFactory, ActionsFactory, PagesFactory);

            DependencyContainer.Initialize(ServiceContainer.Default);
        }

        protected IAppContext App;
        protected ViewInjectionManagerStub ViewInjectionManager;

        protected NetworkServiceStub NetworkService;
        protected HintServiceStub HintService;
        protected LoadingServiceStub LoadingService;
        protected HistoryService HistoryService;

        protected ImagesRepository ImageRepository; //TODO: Make stub

        protected DialogFactoryStub DialogFactory;
        protected DevicesFactory DevicesFactory;
        protected ActionsFactory ActionsFactory;
        protected PagesFactory PagesFactory;

        protected GiveMe GiveMe;
    }
}