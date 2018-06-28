#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using VKMSmalta.Dialogs.Factories;
using VKMSmalta.Services.Navigate;
using VKMSmalta.View.Elements.ViewModel;
using VKMSmalta.View.ViewModel;
using VKMSmalta.ViewModel;

#endregion

namespace VKMSmalta.Services
{
    public class DependencyContainer
    {
        private readonly AppGlobal appGlobal;
        private readonly DialogFactory dialogFactory;

        private DependencyContainer(Config config)
        {
            Config = config;

            appGlobal = new AppGlobal();
            dialogFactory = new DialogFactory();
        }

        public Config Config { get; }

        public static DependencyContainer Instance { get; private set; }

        public static AppGlobal GetApp()
        {
            return Instance?.appGlobal;
        }

        public static DialogFactory GetDialogFactory()
        {
            return Instance?.dialogFactory;
        }

        public static void Initialize(Config config)
        {
            if (Instance == null)
            {
                Instance = new DependencyContainer(config);
            }
        }
    }
}