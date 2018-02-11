using System;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using VKMSmalta.Domain;
using VKMSmalta.Services;
using VKMSmalta.View.ViewModel;
using Action = VKMSmalta.Domain.Action;

namespace VKMSmalta.View.Elements.ViewModel
{
    public abstract class ClickableElementViewModelBase : ElementViewModelBase
    {
        public DelegateCommand ClickCommand { get; set; }

        public ClickableElementViewModelBase()
        {
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick);
        }

        protected virtual void OnClick()
        {
            SendActionToHistoryService();
        }

        protected virtual void SendActionToHistoryService()
        {
            var action = new Action(ActionName.Click, Name);
            HistoryService.Instance.Actions.Add(action);
        }
    }
}