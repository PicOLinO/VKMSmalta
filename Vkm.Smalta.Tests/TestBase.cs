using NUnit.Framework;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Services;
using Vkm.Smalta.Tests.Fakes.ServicesAndFactories;

namespace Vkm.Smalta.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected AppGlobal App;
        protected DialogFactoryStub DialogFactory;
        protected HintServiceStub HintService;
        protected ViewInjectionManagerStub ViewInjectionManager;
        protected LoadingServiceStub LoadingService;

        protected DevicesFactory DevicesFactory;
        protected AlgorithmsFactory AlgorithmsFactory;
        protected ActionsFactory ActionsFactory;

        [SetUp]
        protected virtual void Setup()
        {
            ViewInjectionManager = new ViewInjectionManagerStub();

            var config = new Config("adminUriBase");
            DependencyContainer.Initialize(config, ViewInjectionManager);

            App = DependencyContainer.GetApp();
            DialogFactory = new DialogFactoryStub();
            HintService = new HintServiceStub();
            LoadingService = new LoadingServiceStub();

            DevicesFactory = new DevicesFactory();
            ActionsFactory = new ActionsFactory(HintService);
            AlgorithmsFactory = new AlgorithmsFactory(ActionsFactory);
        }
    }
}
