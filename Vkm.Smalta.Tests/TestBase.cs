using NUnit.Framework;
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
        }
    }
}
