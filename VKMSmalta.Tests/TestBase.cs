using NUnit.Framework;
using VKMSmalta.Services;

namespace VKMSmalta.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        protected AppGlobal App;

        [SetUp]
        protected virtual void Setup()
        {
            var config = new Config("adminUriBase");
            DependencyContainer.InitializeService(config);
            App = DependencyContainer.GetApp();
        }
    }
}
