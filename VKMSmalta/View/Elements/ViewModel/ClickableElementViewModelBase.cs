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
        private readonly HistoryService historyService;

        public DelegateCommand ClickCommand { get; set; }

        public ClickableElementViewModelBase(int value, string name, HistoryService historyService) : base(value, name)
        {
            this.historyService = historyService;
            CreateCommands();
        }

        private void CreateCommands()
        {
            ClickCommand = new DelegateCommand(OnClick, CanOnClick);
        }

        private bool CanOnClick()
        {
            return IsEnabled;
        }

        protected virtual void OnClick()
        {
            SendActionToHistoryService();
        }

        protected virtual void SendActionToHistoryService()
        {
            var action = new Action(ActionName.Click, Name);
            historyService.Actions.Add(action);
        }
    }
}