using System;
using System.Windows;
using DevExpress.Mvvm;

namespace VKMSmalta.View.ViewModel
{
    public class HintViewModel : ViewModelBase
    {
        public DelegateCommand<Window> ClickCommand { get; set; }

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
            ClickCommand = new DelegateCommand<Window>(OnClick);
        }

        private void OnClick(Window window)
        {
            window?.Close();
        }
    }
}