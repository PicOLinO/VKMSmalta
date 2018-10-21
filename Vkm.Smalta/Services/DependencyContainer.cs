#region Usings

using DevExpress.Mvvm;
using Vkm.ComplexSim.Dialogs.Factories;

#endregion

namespace Vkm.ComplexSim.Services
{
    public class DependencyContainer
    {
        private readonly IServiceContainer serviceContainer;

        private DependencyContainer(IServiceContainer serviceContainer)
        {
            this.serviceContainer = serviceContainer;
        }

        public static DependencyContainer Instance { get; private set; }

        public static IAppContext GetApp()
        {
            return Instance?.serviceContainer.GetService<IAppContext>();
        }

        public static IDialogFactory GetDialogFactory()
        {
            return Instance?.serviceContainer.GetService<IDialogFactory>();
        }

        public static IViewInjectionManager GetViewInjectionManager()
        {
            return Instance?.serviceContainer.GetService<IViewInjectionManager>();
        }

        public static void Initialize(IServiceContainer serviceContainer)
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer(serviceContainer);
            }
        }
    }
}