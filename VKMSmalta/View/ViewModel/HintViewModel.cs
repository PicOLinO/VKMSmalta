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
            ClickNextCommand = new DelegateCommand(OnClickNext);
        }

        private void OnClickNext()
        {
            HintService.Instance.ShowNext();
        }
    }
}