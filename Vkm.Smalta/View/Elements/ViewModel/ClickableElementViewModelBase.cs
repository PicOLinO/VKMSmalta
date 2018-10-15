﻿#region Usings

using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Action = Vkm.Smalta.Domain.Action;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public abstract class ClickableElementViewModelBase : ElementViewModelBase
    {
        protected readonly IHistoryService HistoryService;

        protected ClickableElementViewModelBase(int value, string name, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
            HistoryService = ServiceContainer.GetService<IHistoryService>();
            CreateCommands();
        }

        public ICommand MouseLeftButtonDownCommand { get; set; }

        public ICommand MouseLeftButtonUpCommand { get; set; }

        private bool CanOnMouseLeftButtonUse()
        {
            return IsEnabled;
        }

        private void CreateCommands()
        {
            MouseLeftButtonUpCommand = new DelegateCommand(OnMouseLeftButtonUp, CanOnMouseLeftButtonUse);
            MouseLeftButtonDownCommand = new DelegateCommand(OnMouseLeftButtonDown, CanOnMouseLeftButtonUse);
        }

        private void SendActionToHistoryService()
        {
            var action = new Action(ActionName.Click, Name);
            HistoryService.Actions.Add(action);
        }

        protected virtual void OnMouseLeftButtonDown()
        {
        }

        protected virtual void OnMouseLeftButtonUp()
        {
            SendActionToHistoryService();
        }
    }
}