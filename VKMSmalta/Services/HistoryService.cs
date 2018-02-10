using System.Collections.Generic;
using VKMSmalta.Domain;

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

        public HistoryService()
        {
            Actions = new List<Action>();
        }
    }
}