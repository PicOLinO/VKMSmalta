using System;
using Vkm.ComplexSim.Services;

namespace Vkm.ComplexSim.View.Elements.ViewModel
{
    public abstract class InteractiveElementViewModelBase : ElementViewModelBase
    {
        protected readonly IHistoryService HistoryService;

        protected InteractiveElementViewModelBase(int value, string name, int posTop, int posLeft, Enum page) 
            : base(value, name, posTop, posLeft, page)
        {
            HistoryService = ServiceContainer.GetService<IHistoryService>();
        }

        protected abstract void Interact();
        protected abstract bool CanInteract();
    }
}