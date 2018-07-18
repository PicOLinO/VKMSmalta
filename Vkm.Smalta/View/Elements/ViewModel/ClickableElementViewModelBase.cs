#region Usings

using DevExpress.Mvvm;
using Vkm.Smalta.Domain;
using Vkm.Smalta.Services;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel
{
    public abstract class ClickableElementViewModelBase : ElementViewModelBase
    {
        protected readonly HistoryService HistoryService;

        protected ClickableElementViewModelBase(int value, string name, HistoryService historyService) : base(value, name)
        {
            HistoryService = historyService;
            CreateCommands();
        }

        public DelegateCommand MouseLeftButtonDownCommand { get; set; }

        public DelegateCommand MouseLeftButtonUpCommand { get; set; }

        private bool CanOnMouseLeftButtonUse()
        {
            return IsEnabled;
        }

        private void CreateCommands()
        {
            MouseLeftButtonUpCommand = new DelegateCommand(OnMouseLeftButtonUp, CanOnMouseLeftButtonUse);
            MouseLeftButtonDownCommand = new DelegateCommand(OnMouseLeftButtonDown, CanOnMouseLeftButtonUse);
        }

        protected virtual void OnMouseLeftButtonDown()
        {
        }

        protected virtual void OnMouseLeftButtonUp()
        {
            SendActionToHistoryService();
        }

        private void SendActionToHistoryService()
        {
            var action = new Action(ActionName.Click, Name);
            HistoryService.Actions.Add(action);
        }
    }
}