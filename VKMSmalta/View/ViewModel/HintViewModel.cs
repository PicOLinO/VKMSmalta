using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using DevExpress.Mvvm;
using VKMSmalta.Services;

namespace VKMSmalta.View.ViewModel
{
    public class HintViewModel : ViewModelBase
    {
        private readonly int accessibleValue;

        public DelegateCommand ClickNextCommand { get; set; }

        public string HintText
        {
            get { return GetProperty(() => HintText); }
            set { SetProperty(() => HintText, value); }
        }

        public HintViewModel(string hintText, int accessibleValue)
        {
            this.accessibleValue = accessibleValue;
            HintText = hintText;

            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickNextCommand = new DelegateCommand(OnClickNext, CanOnClickNext);
        }

        private bool CanOnClickNext()
        {
            var element = HintService.Instance.GetValuableElementByCurrentHint();
            return element?.Value == accessibleValue;
        }

        private void OnClickNext()
        {
            HintService.Instance.ShowNextHint();
        }
    }
}