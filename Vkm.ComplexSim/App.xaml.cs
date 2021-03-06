﻿#region Usings

using System;
using System.Configuration;
using System.Windows;
using System.Windows.Threading;
using Appccelerate.CommandLineParser;
using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.Factories;
using Vkm.ComplexSim.Services;
using Vkm.ComplexSim.View.Images;

#endregion

namespace Vkm.ComplexSim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var config = CreateConfig();
            
            InitializeDependencies(config);

            ParseArgs(e.Args);

            Current.DispatcherUnhandledException += HandleUnhandledException;
        }

        private void InitializeDependencies(Config config)
        {
            var imagesRepository = new ImagesRepository();
            var messageBoxService = new MessageBoxService();

            ServiceContainer.Default.RegisterService(imagesRepository);
            ServiceContainer.Default.RegisterService(messageBoxService);

            ServiceContainer.Default.RegisterService(ViewInjectionManager.Default);
            ServiceContainer.Default.RegisterService(new HintService());
            ServiceContainer.Default.RegisterService(new LoadingService());
            ServiceContainer.Default.RegisterService(new HistoryService());
            ServiceContainer.Default.RegisterService(new NetworkService(config.AdminUri));
            ServiceContainer.Default.RegisterService(new PagesFactory(imagesRepository));
            ServiceContainer.Default.RegisterService(new DialogFactory(messageBoxService));
            ServiceContainer.Default.RegisterService(new ActionsFactory());
            ServiceContainer.Default.RegisterService(new DevicesFactory());
            ServiceContainer.Default.RegisterService(new AppContext());
            ServiceContainer.Default.RegisterService(new ImagesRepository());

            DependencyContainer.Initialize(ServiceContainer.Default);
        }

        private Config CreateConfig()
        {
            var adminAddress = ConfigurationManager.AppSettings["AdminBaseAddress"];

            return new Config(adminAddress);
        }

        private void HandleUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var dialogFactory = DependencyContainer.GetDialogFactory();
            dialogFactory.ShowErrorMessage(e.Exception);
            e.Handled = true;
        }

        private void ParseArgs(string[] args)
        {
            var app = DependencyContainer.GetApp();

            var configuration = CommandLineParserConfigurator
                                .Create()
                                .WithSwitch("debug", () => app.IsDebug = true)
                                .DescribedBy("Enable debug mode")
                                .WithSwitch("authorized", () => app.IsAuthorized = true)
                                .DescribedBy("Dont needed to authorize")
                                .BuildConfiguration();
            var parser = new CommandLineParser(configuration);
            var parseResult = parser.Parse(args);

            if (!parseResult.Succeeded)
            {
                throw new ArgumentException("Unknown arguments");
            }
        }
    }
}