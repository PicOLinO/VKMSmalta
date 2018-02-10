using System;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using VKMSmalta.View;

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

        public void ShowHint(double top, double left, string text)
        {
            var dialog = new Hint(text)
                         {
                             Top = top,
                             Left = left
                         };
            dialog.ShowDialog();
        }
    }
}