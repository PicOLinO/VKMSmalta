using System;

namespace VKMSmalta.Services
{
    public class HintService
    {
        public static HintService Instance { get; private set; }

        public static void InitializeService()
        {
            if (Instance == null)
            {
                Instance = new HintService();
            }
        }

        public void ShowHint(double posTop, double posLeft, string text)
        {
            throw new NotImplementedException();
        }
    }
}