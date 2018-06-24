#region Usings

using System;
using System.Configuration;
using System.Windows;
using System.Windows.Threading;
using Appccelerate.CommandLineParser;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Services;

#endregion

namespace VKMSmalta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var config = CreateConfig();

            DependencyContainer.InitializeService(config);
            NetworkService.InitializeService(config.AdminUri);

            ParseArgs(e.Args);

            Current.DispatcherUnhandledException += HandleUnhandledException;
        }

        private Config CreateConfig()
        {
            var adminAddress = ConfigurationManager.AppSettings["AdminBaseAddress"];

            return new Config(adminAddress);
        }

        private void HandleUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            DialogFactory.ShowErrorMessage(e.Exception);
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