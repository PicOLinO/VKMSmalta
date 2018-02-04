using System;
using DevExpress.Mvvm;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class ElementViewModelBase : ViewModelBase
    {
        public DelegateCommand ShowHintCommand { get; set; }

        protected ElementViewModelBase()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            ShowHintCommand = new DelegateCommand(OnShowHint);
        }

        private void OnShowHint()
        {
            throw new NotImplementedException();
        }

        public double PosLeft { get; set; }
        public double PosTop { get; set; }
    }
}