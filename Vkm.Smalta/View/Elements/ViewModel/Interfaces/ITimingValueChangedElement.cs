#region Usings

using System.Timers;

#endregion

namespace Vkm.Smalta.View.Elements.ViewModel.Interfaces
{
    public interface ITimingValueChangedElement
    {
        Timer Timer { get; }
    }
}