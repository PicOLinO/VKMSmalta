using System;
using System.Collections.Generic;
using VKMSmalta.Domain;
using VKMSmalta.View.Elements.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.Services
{
    public class HistoryService
    {
        public static HistoryService Instance { get; private set; }

        public static void InitializeService()
        {
            if (Instance == null)
            {
                Instance = new HistoryService();
            }
        }

        public List<Action> Actions { get; }

        private HistoryService()
        {
            Actions = new List<Action>();
        }

        public int GetValueByAlgorithm(Algorithm algorithm, List<IValuableElement> elements)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Actions.Clear();
        }
    }
}