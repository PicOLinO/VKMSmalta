#region Usings

using DevExpress.Mvvm;
using Vkm.Smalta.Dialogs.Factories;

#endregion

namespace Vkm.Smalta.Services
{
    public class DependencyContainer
    {
        private readonly IViewInjectionManager viewInjectionManager;
        private readonly AppGlobal appGlobal;
        private readonly DialogFactory dialogFactory;

        private DependencyContainer(Config config, IViewInjectionManager viewInjectionManager)
        {
            Config = config;

            appGlobal = new AppGlobal();
            dialogFactory = new DialogFactory();

            this.viewInjectionManager = viewInjectionManager;
        }

        public Config Config { get; }

        public static DependencyContainer Instance { get; private set; }

        public static AppGlobal GetApp()
        {
            return Instance?.appGlobal;
        }

        public static IViewInjectionManager GetViewInjectionManager()
        {
            return Instance?.viewInjectionManager;
        }

        public static DialogFactory GetDialogFactory()
        {
            return Instance?.dialogFactory;
        }

        public static void Initialize(Config config, IViewInjectionManager viewInjectionManager)
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer(config, viewInjectionManager);
            }
        }
    }
}