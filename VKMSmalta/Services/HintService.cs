using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using VKMSmalta.Domain;
using VKMSmalta.View;
using VKMSmalta.View.Elements.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Services
{
    public class HintService : IDisposable
    {
        public static HintService Instance { get; private set; }

        private List<ElementViewModelBase> Elements { get; set; }
        private Algorithm Algorithm { get; set; }
        private Action CurrentAction { get; set; }

        public static void InitializeService()
        {
            if (Instance == null)
            {
                Instance = new HintService();
            }
        }

        public void StartTraining(Algorithm algorithm, List<ElementViewModelBase> elements)
        {
            Elements = elements;
            Algorithm = algorithm;

            ShowNext();
        }

        public void ShowNext()
        {
            Action action;
            if (CurrentAction == null)
            {
                action = Algorithm.Actions.FirstOrDefault();
            }
            else
            {
                action = Algorithm.Actions.Find(CurrentAction)?.Next?.Value;
                HideCurrentHint();
            }

            if (action == null)
            {
                VkmNavigationService.Instance.ExitDevicePageWithTrainingCompleteMessage();
                Dispose();
                return;
            }

            var element = Elements.Single(e => e.Name == action?.ParentElementName);

            element.Hint = action.Hint;
            element.IsHintOpen = true;

            CurrentAction = action;
        }

        public void HideCurrentHint()
        {
            var element = Elements.Single(e => e.Name == CurrentAction?.ParentElementName);

            element.IsHintOpen = false;
            element.Hint = null;

            CurrentAction = null;
        }

        public void Dispose()
        {
            Elements = null;
            Algorithm = null;
            CurrentAction = null;
        }

        public void Reset()
        {
            CurrentAction = null;
        }
    }
}