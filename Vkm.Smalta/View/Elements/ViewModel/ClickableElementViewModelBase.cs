#region Usings

using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;
using Action = Vkm.Smalta.Domain.Action;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public abstract class ClickableElementViewModelBase : InteractiveElementViewModelBase
    {

        protected ClickableElementViewModelBase(int value, string name, int posTop, int posLeft, Enum page) : base(value, name, posTop, posLeft, page)
        {
            CreateCommands();
        }
        
        public ICommand MouseClickCommand { get; set; }

        protected override bool CanInteract()
        {
            return IsEnabled;
        }

        protected override void Interact()
        {
            SendActionToHistoryService();
        }

        private void CreateCommands()
        {
            MouseClickCommand = new DelegateCommand(Interact, CanInteract);
        }

        private void SendActionToHistoryService()
        {
            var action = new Action(ActionName.Click, Name);
            HistoryService.Actions.Add(action);
        }
    }
}