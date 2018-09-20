#region Usings

using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.Factories;

#endregion

namespace Vkm.Smalta.Services
{
    public class DependencyContainer
    {
        private readonly AppGlobal appGlobal;

        private readonly IServiceContainer serviceContainer;

        private DependencyContainer(Config config, IServiceContainer serviceContainer)
        {
            Config = config;

            this.serviceContainer = serviceContainer; 

            appGlobal = new AppGlobal();
        }

        public static void Initialize(Config config, IServiceContainer serviceContainer)
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer(config, serviceContainer);
            }
        }

        public Config Config { get; }

        public static DependencyContainer Instance { get; private set; }

        public static AppGlobal GetApp()
        {
            return Instance?.appGlobal;
        }

        public static IViewInjectionManager GetViewInjectionManager()
        {
            return Instance?.serviceContainer.GetService<IViewInjectionManager>();
        }

        public static IDialogFactory GetDialogFactory()
        {
            return Instance?.serviceContainer.GetService<IDialogFactory>();
        }
    }
}