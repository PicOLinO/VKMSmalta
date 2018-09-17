﻿using System.Collections.Generic;
using NUnit.Framework;
using Vkm.Smalta.Dialogs.Factories;
using Vkm.Smalta.Dialogs.Factories.Algorithms;
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
        protected HistoryService HistoryService;

        protected DevicesFactory DevicesFactory;
        protected ActionsFactory ActionsFactory;
        protected PagesFactory PagesFactory;

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
            HistoryService = new HistoryService();

            ActionsFactory = new ActionsFactory(HintService);
            var algorithmsFactoriesCollection = new List<AlgorithmsFactoryBase>
                                                {
                                                    new SmaltaAlgorithmsFactory(ActionsFactory),
                                                    new RlsOncAlgorithmsFactory(ActionsFactory)
                                                };
            DevicesFactory = new DevicesFactory(algorithmsFactoriesCollection);
            PagesFactory = new PagesFactory(HistoryService);
        }
    }
}
