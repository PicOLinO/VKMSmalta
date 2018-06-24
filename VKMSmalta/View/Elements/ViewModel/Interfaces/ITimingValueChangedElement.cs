#region Usings

using System.Timers;

#endregion

namespace VKMSmalta.View.Elements.ViewModel.Interfaces
{
    public interface ITimingValueChangedElement
    {
        Timer Timer { get; }
    }
}