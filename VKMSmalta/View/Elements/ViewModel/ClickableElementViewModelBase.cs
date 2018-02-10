using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class ClickableElementViewModelBase : ElementViewModelBase
    {
        public DelegateCommand ClickCommand { get; set; }

        protected virtual void CreateCommands()
        {
        }
    }
}