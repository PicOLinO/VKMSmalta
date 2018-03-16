using System;
using System.Timers;
using VKMSmalta.View.Elements.ViewModel.Interfaces;

namespace VKMSmalta.View.Elements.ViewModel
{
    public class VkmBlackTriangleArrowViewModel : ElementViewModelBase, ITimingValueChangedElement, IDisposable
    {
        private readonly int startupRotation;
        private int neededRotation;

        public Timer Timer { get; }

        public int RotationDegrees
        {
            get { return GetProperty(() => RotationDegrees); }
            set { SetProperty(() => RotationDegrees, value); }
        }

        protected override void OnValueChanged()
        {
            base.OnValueChanged();

            neededRotation = (11 * Value) + startupRotation;
            Timer.Start();
        }

        public VkmBlackTriangleArrowViewModel(int value, string name, int startupRotation) : base(value, name)
        {
            Timer = new Timer(100);
            Timer.Elapsed += TimerOnElapsed;

            this.startupRotation = RotationDegrees = startupRotation;
            Value = value;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (RotationDegrees < neededRotation)
            {
                RotationDegrees += 1;
            }
            else if (RotationDegrees > neededRotation)
            {
                RotationDegrees -= 1;
            }
            else
            {
                Timer.Stop();
            }
        }

        public void Dispose()
        {
            Timer.Elapsed -= TimerOnElapsed;
            Timer?.Dispose();
        }
    }
}