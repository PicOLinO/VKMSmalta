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
        public DelegateCommand ClickNextCommand { get; set; }

        public string HintText
        {
            get { return GetProperty(() => HintText); }
            set { SetProperty(() => HintText, value); }
        }

        public HintViewModel(string hintText)
        {
            CreateCommands();
            HintText = hintText;
        }

        private void CreateCommands()
        {
            ClickNextCommand = new DelegateCommand(OnClickNext, CanOnClickNext);
        }

        private bool CanOnClickNext()
        {
            //TODO: В идеале тут должна быть проверка на текущее Value элемента, к которому относится данный Hint. Реализовать по возможности.
            return true;
        }

        private void OnClickNext()
        {
            HintService.Instance.ShowNextHint();
        }
    }
}