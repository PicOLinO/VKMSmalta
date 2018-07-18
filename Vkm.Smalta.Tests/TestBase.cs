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
            var config = new Config("adminUriBase");
            DependencyContainer.Initialize(config);

            App = DependencyContainer.GetApp();
            DialogFactory = new DialogFactoryStub();
            HintService = new HintServiceStub();
            ViewInjectionManager = new ViewInjectionManagerStub();
            LoadingService = new LoadingServiceStub();
        }
    }
}
