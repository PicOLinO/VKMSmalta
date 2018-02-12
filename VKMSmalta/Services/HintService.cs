using System;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using VKMSmalta.View;
using VKMSmalta.View.Elements.ViewModel;

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

        public void ShowHint(ElementViewModelBase element, int hintIndex)
        {
            element.Hint = element.HintsCollection[hintIndex];
            element.IsHintOpen = true;
        }
    }
}