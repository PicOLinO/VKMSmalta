using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using DevExpress.Mvvm;

namespace VKMSmalta.View.ViewModel
{
    public class HintViewModel : ViewModelBase
    {
        public DelegateCommand ClickCommand { get; set; }

        public string HintText
        {
            get { return GetProperty(() => HintText); }
            set { SetProperty(() => HintText, value); }
        }

        public HintViewModel()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        private void OnClick()
        {
            
        }
    }
}